using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Pedido
    {
        public Pedido()
        {
            ProcesoVenta = new HashSet<ProcesoVenta>();
            ProductoPedido = new HashSet<ProductoPedido>();
        }

        public int IdPedido { get; set; }
        public string Descripcion { get; set; }
        public string Vigencia { get; set; }
        public int? Usuario { get; set; }

        public Usuario UsuarioNavigation { get; set; }
        public ICollection<ProcesoVenta> ProcesoVenta { get; set; }
        public ICollection<ProductoPedido> ProductoPedido { get; set; }
    }
}
