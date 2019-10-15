using FrutosMaipo.Feria.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutosMaipo.Feria.Service.Infrastructure.Interfaces
{
    public interface ISendEmailService
    {
        Task<bool> SendEmail(SendEmailParameterModel emailDestino);
    }
}
