using Microsoft.AspNetCore.Identity;
using Restaurante.Infrastructure.Persistence;
using Restaurante.Core.Application;
using RestaurantApi.WebApi.Extensions;
using Restaurante.Infrastructure.Identity;
using Restaurante.Infrastructure.Identity.Entities;
using Restaurante.Infrastructure.Identity.Seeds;
using Restaurante.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerExtension();
builder.Services.AddApiVersioningExtension();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultAdministratorUser.SeedAsync(userManager, roleManager);
        await DefaultSuperAdminUser.SeedAsync(userManager, roleManager);
        await DefaultWaiterUser.SeedAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {

    }
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSwaggerExtension();
app.UseAuthorization();
app.UseAuthorization();
app.UseHealthChecks("/health");
app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
app.Run();
