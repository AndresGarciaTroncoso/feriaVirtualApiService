using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Contrato
    {
        public Contrato()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdContrato { get; set; }
        public DateTime? FechaContrato { get; set; }
        public string Vigencia { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
