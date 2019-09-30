using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class TipoEstado
    {
        public TipoEstado()
        {
            Estado = new HashSet<Estado>();
        }

        public int IdTipoEstado { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Estado> Estado { get; set; }
    }
}
