using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Estado
    {
        public Estado()
        {
            ProcesoVenta = new HashSet<ProcesoVenta>();
            SubastaTransporte = new HashSet<SubastaTransporte>();
        }

        public int IdEstado { get; set; }
        public string Descripcion { get; set; }
        public int? TipoEstado { get; set; }

        public TipoEstado TipoEstadoNavigation { get; set; }
        public ICollection<ProcesoVenta> ProcesoVenta { get; set; }
        public ICollection<SubastaTransporte> SubastaTransporte { get; set; }
    }
}
