using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Funcion
    {
        public Funcion()
        {
            FuncionRol = new HashSet<FuncionRol>();
        }

        public int IdFuncion { get; set; }
        public string TipoFuncion { get; set; }
        public string Descripcion { get; set; }

        public ICollection<FuncionRol> FuncionRol { get; set; }
    }
}
