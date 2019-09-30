using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class EstadoSubasta
    {
        public int IdEstadoSubasta { get; set; }
        public int? Subasta { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaEstado { get; set; }

        public Estado EstadoNavigation { get; set; }
    }
}
