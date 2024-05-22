using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Core.Application.Dtos.Account
{
    public class JwtResponse
    {
        public string Error { get; set; }
        public bool HasError { get; set; }
    }
}
