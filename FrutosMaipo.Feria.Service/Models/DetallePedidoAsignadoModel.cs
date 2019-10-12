using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutosMaipo.Feria.Service.Models
{
    public class DetallePedidoAsignadoModel
    {
        public int idProcesoVenta { get; set; }
        public string fechaInicio { get; set; }
        public string tipoVenta { get; set; }
        public int idEstado { get; set; }
        public string estado { get; set; }
        public int idPedido { get; set; }
    }
}
