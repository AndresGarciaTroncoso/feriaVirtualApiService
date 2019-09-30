using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Solicitud = new HashSet<Solicitud>();
        }

        public int Rut { get; set; }
        public string Dv { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Vigencia { get; set; }
        public int? Contrato { get; set; }
        public int? Rol { get; set; }

        public Contrato ContratoNavigation { get; set; }
        public Rol RolNavigation { get; set; }
        public ICollection<Solicitud> Solicitud { get; set; }
    }
}
