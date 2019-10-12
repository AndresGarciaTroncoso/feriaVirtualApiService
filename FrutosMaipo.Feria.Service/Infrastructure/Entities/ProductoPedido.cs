using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class ProductoPedido
    {
        public int IdProductoPedido { get; set; }
        public int? Pedido { get; set; }
        public int? Producto { get; set; }
        public double? Kilogramos { get; set; }
        public int? Productor { get; set; }

        public Pedido PedidoNavigation { get; set; }
        public Producto ProductoNavigation { get; set; }
    }
}
