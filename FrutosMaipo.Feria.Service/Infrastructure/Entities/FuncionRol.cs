using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class FuncionRol
    {
        public int IdFuncionRol { get; set; }
        public int? Rol { get; set; }
        public int? Funcion { get; set; }

        public Funcion FuncionNavigation { get; set; }
        public Rol RolNavigation { get; set; }
    }
}
