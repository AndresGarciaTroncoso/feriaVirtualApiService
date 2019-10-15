using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class SubastaTransporte
    {
        public SubastaTransporte()
        {
            RequisitoTransporte = new HashSet<RequisitoTransporte>();
            Transporte = new HashSet<Transporte>();
        }

        public int IdSubasta { get; set; }
        public int? ProcesoVenta { get; set; }
        public int? Estado { get; set; }

        public Estado EstadoNavigation { get; set; }
        public ProcesoVenta ProcesoVentaNavigation { get; set; }
        public ICollection<RequisitoTransporte> RequisitoTransporte { get; set; }
        public ICollection<Transporte> Transporte { get; set; }
    }
}
