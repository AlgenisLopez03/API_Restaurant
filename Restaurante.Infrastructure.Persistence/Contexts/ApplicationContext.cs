using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Domain.Common;
using Restaurante.Core.Domain.Entities;

namespace Restaurante.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables
            modelBuilder.Entity<Ingrediente>()
                .ToTable("Ingredientes");

            modelBuilder.Entity<Plato>()
                .ToTable("Platos");

            modelBuilder.Entity<Orden>()
                .ToTable("Ordenes");

            modelBuilder.Entity<Mesa>()
                .ToTable("Mesas");
            #endregion

            #region primary keys
             modelBuilder.Entity<Ingrediente>()
                .HasKey(ingrediente => ingrediente.Id);

            modelBuilder.Entity<Plato>()
                .HasKey(plato => plato.Id);

            modelBuilder.Entity<Orden>()
                .HasKey(orden => orden.Id);

            modelBuilder.Entity<Mesa>()
                .HasKey(mesa => mesa.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<Plato>()
            .HasOne(p => p.Ingrediente)
           .WithMany(i => i.Platos)
          .HasForeignKey(p => p.IngredienteID)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Plato)
                .WithMany(p => p.Ordenes)
                .HasForeignKey(o => o.PlatoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Mesa)
                .WithMany(m => m.Ordenes)
                .HasForeignKey(o => o.MesaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ingrediente>()
                .HasMany(i => i.Platos)
                .WithOne(p => p.Ingrediente)
                .HasForeignKey(p => p.IngredienteID)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region"property configuration"
            modelBuilder.Entity<Plato>()
             .Property(p => p.Nombre)
               .HasMaxLength(255); 

            modelBuilder.Entity<Mesa>()
                .Property(m => m.Descripcion)
                .IsRequired(); 

            modelBuilder.Entity<Ingrediente>()
                .Property(i => i.Nombre)
                .IsRequired();

            modelBuilder.Entity<Orden>()
                .Property(o => o.Estado)
                .IsRequired();

            #endregion
        }
    }
}
