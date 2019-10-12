using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Transporte
    {
        public int IdTransporte { get; set; }
        public string Patente { get; set; }
        public int? CapacidadCarga { get; set; }
        public string Refrigeracion { get; set; }
        public int? Transportista { get; set; }

        public Usuario TransportistaNavigation { get; set; }
    }
}
