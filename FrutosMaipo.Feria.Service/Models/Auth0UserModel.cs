using System;

namespace FrutosMaipo.Feria.Service.Models
{
    public class Auth0UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string NombreCompleto { get; set; }
        public string Vigencia { get; set; }
        public DateTime FechaInicioContrato { get; set; }
        public DateTime FechaActualContrato { get; set; }
        public DateTime FechaTerminoContrato { get; set; }
        public string VigenciaContrato { get; set; }
        public int? Rol { get; set; }

    }
}
