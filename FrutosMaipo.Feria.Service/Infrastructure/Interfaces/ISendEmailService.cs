using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutosMaipo.Feria.Service.Infrastructure.Interfaces
{
    public interface ISendEmailService
    {
        Task<bool> SendEmail(string emailDestino);
    }
}
