using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class EstadoProcesoVenta
    {
        public int IdEstadoProcesoVenta { get; set; }
        public int? ProcesoVenta { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaEstado { get; set; }

        public ProcesoVenta Estado1 { get; set; }
        public Estado EstadoNavigation { get; set; }
    }
}
