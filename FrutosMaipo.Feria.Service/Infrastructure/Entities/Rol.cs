using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            FuncionRol = new HashSet<FuncionRol>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public string Vigencia { get; set; }

        public ICollection<FuncionRol> FuncionRol { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
