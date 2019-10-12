using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class EstadoSubasta
    {
        public int IdEstadoSubasta { get; set; }
        public int? Subasta { get; set; }
        public DateTime? FechaEstado { get; set; }
    }
}
