using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Transportista
    {
        public Transportista()
        {
            Subasta = new HashSet<Subasta>();
        }

        public int Rut { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }

        public ICollection<Subasta> Subasta { get; set; }
    }
}
