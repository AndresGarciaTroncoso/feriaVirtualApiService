using System;
using System.Collections.Generic;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Contrato = new HashSet<Contrato>();
            Pedido = new HashSet<Pedido>();
        }

        public int Rut { get; set; }
        public string Dv { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Vigencia { get; set; }
        public int? Rol { get; set; }

        public Rol RolNavigation { get; set; }
        public ICollection<Contrato> Contrato { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
    }
}
