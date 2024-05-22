using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.Dtos.Account
{
    public class PasswordRequest
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
