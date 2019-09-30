using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Subasta
    {
        public int IdSubasta { get; set; }
        public int? Tranportista { get; set; }
        public int? ProcesoVenta { get; set; }

        public ProcesoVenta ProcesoVentaNavigation { get; set; }
        public Transportista TranportistaNavigation { get; set; }
    }
}
