using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Contrato
    {
        public int IdContrato { get; set; }
        public int? Productor { get; set; }
        public DateTime? FechaInicioContrato { get; set; }
        public DateTime? FechaActualContrato { get; set; }
        public DateTime? FechaTerminoContrato { get; set; }
        public string Vigencia { get; set; }

        public Usuario ProductorNavigation { get; set; }
    }
}
