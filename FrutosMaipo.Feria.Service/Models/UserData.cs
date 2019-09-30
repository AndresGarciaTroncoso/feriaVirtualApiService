using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrutosMaipo.Feria.Service.Infrastructure.Interfaces;

namespace FrutosMaipo.Feria.Service.Models
{
    public class UserData
    {
        public UsuarioModel usuario { get; set; }
        public RolFuncionModel rolFunciones { get; set; }
    }
}
