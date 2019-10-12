using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class SubastaTransporte
    {
        public int IdSubasta { get; set; }
        public int? ProcesoVenta { get; set; }
        public int? Transportista { get; set; }
        public int? Precio { get; set; }
        public string Seleccionado { get; set; }
        public int? Estado { get; set; }

        public Estado EstadoNavigation { get; set; }
        public ProcesoVenta ProcesoVentaNavigation { get; set; }
    }
}
