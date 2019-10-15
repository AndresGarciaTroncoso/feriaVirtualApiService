using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class RequisitoTransporte
    {
        public int IdRequisito { get; set; }
        public int? Subasta { get; set; }
        public int? CapacidadDeCarga { get; set; }
        public string Refigeracion { get; set; }
        public int? Precio { get; set; }

        public SubastaTransporte SubastaNavigation { get; set; }
    }
}
