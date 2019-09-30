using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            ProductoPedido = new HashSet<ProductoPedido>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Precio { get; set; }
        public string Imagen { get; set; }

        public ICollection<ProductoPedido> ProductoPedido { get; set; }
    }
}
