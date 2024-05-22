using Restaurante.Core.Application.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        //Task<string> ConfirmEmailAsync(string userId, string token);
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task LogOutAsync();
        Task<List<AccountResponse>> GetUsersAsync();
        Task<RegisterResponse> RegisterWaiterAsync(RegisterRequest request);
        Task<RegisterResponse> RegisterAdministratorAsync(RegisterRequest request);
    }
}
