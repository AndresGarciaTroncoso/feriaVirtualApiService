using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutosMaipo.Feria.Service.Config
{
    public class SendEmailConfig
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string AsuntoReporteVenta { get; set; }
        public string CuerpoReporteVenta { get; set; }
        public string SmtpClientEmail  { get; set; }
        public int EmailPort { get; set; }
    }
}
