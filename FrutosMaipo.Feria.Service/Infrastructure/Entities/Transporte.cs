using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Transporte
    {
        public int IdTransporte { get; set; }
        public int? Subasta { get; set; }
        public string Patente { get; set; }
        public int? CapacidadCarga { get; set; }
        public string Refrigeracion { get; set; }
        public int? Transportista { get; set; }
        public int? Precio { get; set; }
        public string Seleccionado { get; set; }

        public SubastaTransporte SubastaNavigation { get; set; }
    }
}
