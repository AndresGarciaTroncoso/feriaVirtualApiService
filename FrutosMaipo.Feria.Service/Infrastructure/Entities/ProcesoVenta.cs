using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class ProcesoVenta
    {
        public ProcesoVenta()
        {
            Subasta = new HashSet<Subasta>();
            SubastaTransporte = new HashSet<SubastaTransporte>();
            Venta = new HashSet<Venta>();
        }

        public int IdProcesoVenta { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }
        public int? TipoVenta { get; set; }
        public int? Estado { get; set; }
        public int? Pedido { get; set; }
        public int? Total { get; set; }

        public Estado EstadoNavigation { get; set; }
        public Pedido PedidoNavigation { get; set; }
        public TipoVenta TipoVentaNavigation { get; set; }
        public ICollection<Subasta> Subasta { get; set; }
        public ICollection<SubastaTransporte> SubastaTransporte { get; set; }
        public ICollection<Venta> Venta { get; set; }
    }
}
