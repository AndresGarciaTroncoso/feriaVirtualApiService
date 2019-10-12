using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutosMaipo.Feria.Service.Models
{
    public class ProductorToProductoModel
    {
        public int idProductor { get; set; }
        public int idPedido { get; set; }
        public IList<int> idProducto { get; set; }
    }
}
