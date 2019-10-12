using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutosMaipo.Feria.Service.Models
{
    public class ProductorProductoPedidoModel
    {
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public string imageProducto { get; set; }
        public int precioProducto { get; set; }
        public double cantidadPedido { get; set; }
    }
}
