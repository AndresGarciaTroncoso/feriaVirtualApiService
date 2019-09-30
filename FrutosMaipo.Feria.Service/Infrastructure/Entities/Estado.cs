using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Estado
    {
        public Estado()
        {
            EstadoProcesoVenta = new HashSet<EstadoProcesoVenta>();
            EstadoSubasta = new HashSet<EstadoSubasta>();
        }

        public int IdEstado { get; set; }
        public string Descripcion { get; set; }
        public int? TipoEstado { get; set; }

        public TipoEstado TipoEstadoNavigation { get; set; }
        public ICollection<EstadoProcesoVenta> EstadoProcesoVenta { get; set; }
        public ICollection<EstadoSubasta> EstadoSubasta { get; set; }
    }
}
