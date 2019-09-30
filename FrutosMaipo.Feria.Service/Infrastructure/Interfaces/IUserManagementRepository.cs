using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrutosMaipo.Feria.Service.Models;

namespace FrutosMaipo.Feria.Service.Infrastructure.Interfaces
{
    public interface IUserManagementRepository
    {
        Task<bool> UpdateStatusAuth0(string idAssociated);
    }
}
