using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Pedido
    {
        public Pedido()
        {
            ProductoPedido = new HashSet<ProductoPedido>();
            Solicitud = new HashSet<Solicitud>();
        }

        public int IdPedido { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Vigencia { get; set; }

        public ICollection<ProductoPedido> ProductoPedido { get; set; }
        public ICollection<Solicitud> Solicitud { get; set; }
    }
}
