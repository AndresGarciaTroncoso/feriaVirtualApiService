using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutosMaipo.Feria.Service.Models
{
    public class PedidoModel
    {
        public int idUsuario { get; set; }
        public int total { get; set; }
        public IList<ProductoPedidoModel> productosPedido { get; set; }
    }

    public class ProductoPedidoModel
    {
        public int idProducto { get; set; }
        public int cantidad { get; set; }
    }

}
