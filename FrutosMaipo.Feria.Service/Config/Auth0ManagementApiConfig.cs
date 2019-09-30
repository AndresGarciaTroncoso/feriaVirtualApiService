using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutosMaipo.Feria.Service.Config
{
    public class Auth0ManagementApiConfig
    {
        public string Connection { get; set; }
        public string Auth0Domain { get; set; }
        public string CreateUserEndpoint { get; set; }
        public string TokenEndpoint { get; set; }
        public string ClientId { get; set; }
        public string Audience { get; set; }
        public string ClientSecret { get; set; }
        public string TemporaryPass { get; set; }
        public string Jobs { get; set; }
    }
}
