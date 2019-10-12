using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Venta
    {
        public int IdVenta { get; set; }
        public int? ProcesoVenta { get; set; }
        public string Pagado { get; set; }
        public int? TotalPagado { get; set; }

        public ProcesoVenta ProcesoVentaNavigation { get; set; }
    }
}
