using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class TipoVenta
    {
        public TipoVenta()
        {
            ProcesoVenta = new HashSet<ProcesoVenta>();
        }

        public int IdTipoVenta { get; set; }
        public string Descipcion { get; set; }

        public ICollection<ProcesoVenta> ProcesoVenta { get; set; }
    }
}
