using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class ProcesoVenta
    {
        public ProcesoVenta()
        {
            EstadoProcesoVenta = new HashSet<EstadoProcesoVenta>();
            Subasta = new HashSet<Subasta>();
        }

        public int IdProcesoVenta { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }
        public int? Solicitud { get; set; }
        public int? TipoVenta { get; set; }
        public int? Estado { get; set; }

        public Solicitud SolicitudNavigation { get; set; }
        public TipoVenta TipoVentaNavigation { get; set; }
        public ICollection<EstadoProcesoVenta> EstadoProcesoVenta { get; set; }
        public ICollection<Subasta> Subasta { get; set; }
    }
}
