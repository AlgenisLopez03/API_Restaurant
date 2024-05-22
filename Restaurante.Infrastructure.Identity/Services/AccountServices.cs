using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantApi.Core.Domain.Settings;
using Restaurante.Core.Application.Dtos.Account;
using Restaurante.Core.Application.Enums;
using Restaurante.Core.Application.Interfaces.Services;
using Restaurante.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Identity.Services
{
    public class AccountServices : IUsuarioService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSettings _jWTSettings;

        public AccountServices(UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IOptions<JWTSettings> jWTSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jWTSettings = jWTSettings.Value;

        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {

            AuthenticationResponse response = new();

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                response.HasError = true;
                response.Error = $"You don't have an account with this email {request.Email}";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Invalid credential for {request.Email}";
                return response;
            }

            if (!user.EmailConfirmed)
            {
                response.HasError = true;
                response.Error = $"Your Account is disable, Contact an Administrator.";
                return response;
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);

            response.Id = user.Id;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            response.Email = user.Email;
            response.UserName = user.UserName;
            response.Phone = user.PhoneNumber;

            var RoleList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            response.Roles = RoleList.ToList();
            response.IsVerified = user.EmailConfirmed;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            var generateRefreshToken = GenerateRefreshToken();

            response.RefreshToken = generateRefreshToken.Token;

            return response;
        }

        public async Task<List<AccountResponse>> GetUsersAsync()
        {

            List<AccountResponse> accounts = new();

            var response = await _userManager.Users.ToListAsync();

            foreach (ApplicationUser user in response)
            {
                var roles = await _userManager.GetRolesAsync(user);

                AccountResponse account = new()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Roles = roles.ToList(),
                    UserName = user.UserName,
                    IsVerified = user.EmailConfirmed,
                    Phone = user.PhoneNumber
                };

                accounts.Add(account);
            }

            return accounts;
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<RegisterResponse> RegisterWaiterAsync(RegisterRequest request)
        {

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);

            if (userWithSameEmail != null)
            {
                return new() { HasError = true, Error = $"This email {request.Email} already used." };
            }

            var userWithSameUsername = await _userManager.FindByNameAsync(request.Username);

            if (userWithSameUsername != null)
            {
                return new() { HasError = true, Error = "This username has been taken." };
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                LastName = request.LastName,
                FirstName = request.Name,
                EmailConfirmed = true,
                PhoneNumber = request.Phone,
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.WAITER.ToString());
            }
            else
            {
                return new() { HasError = true, Error = $"An Error ocurred, please try again." };
            }

            return new() { HasError = false };

        }
        public async Task<RegisterResponse> RegisterAdministratorAsync(RegisterRequest request)
        {

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);

            if (userWithSameEmail != null)
            {
                return new() { HasError = true, Error = $"This email {request.Email} already used." };
            }

            var userWithSameUsername = await _userManager.FindByNameAsync(request.Username);

            if (userWithSameUsername != null)
            {
                return new() { HasError = true, Error = "This username has been taken." };
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                LastName = request.LastName,
                FirstName = request.Name,
                EmailConfirmed = true,
                PhoneNumber = request.Phone,
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.ADMINISTRATOR.ToString());
            }
            else
            {
                return new() { HasError = true, Error = $"An Error ocurred, please try again." };
            }

            return new() { HasError = false };

        }

        #region Private Methods

        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {

            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            var roleClaim = new List<Claim>();

            foreach (string roles in userRoles)
            {
                roleClaim.Add(new("roles", roles));
            }

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id),

            }
            .Union(userClaims)
            .Union(roleClaim);


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWTSettings.Key));

            var signInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jWTSettings.Issuer,
                audience: _jWTSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jWTSettings.DurationInMinutes),
                signingCredentials: signInCredentials
                );

            return jwtSecurityToken;

        }

        private RefreshToken GenerateRefreshToken()
        {
            return new()
            {

                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,


            };

        }

        private string RandomTokenString()
        {

            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();

            var randomBytes = new byte[40];

            rngCryptoServiceProvider.GetBytes(randomBytes);

            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

        #endregion
    }
}
