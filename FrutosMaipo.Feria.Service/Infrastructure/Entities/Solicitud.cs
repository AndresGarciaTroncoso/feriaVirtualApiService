using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Solicitud
    {
        public Solicitud()
        {
            ProcesoVenta = new HashSet<ProcesoVenta>();
        }

        public int IdSolicitud { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public int? Pedido { get; set; }
        public int? Usuario { get; set; }

        public Pedido PedidoNavigation { get; set; }
        public Usuario UsuarioNavigation { get; set; }
        public ICollection<ProcesoVenta> ProcesoVenta { get; set; }
    }
}
