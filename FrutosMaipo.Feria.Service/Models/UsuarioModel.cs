using FrutosMaipo.Feria.Service.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutosMaipo.Feria.Service.Models
{
    public class UsuarioModel
    {
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Vigencia { get; set; }
        public int? Contrato { get; set; }
        public int? Rol { get; set; }
        
        //public ICollection<Solicitud> Solicitud { get; set; }

    }
}
