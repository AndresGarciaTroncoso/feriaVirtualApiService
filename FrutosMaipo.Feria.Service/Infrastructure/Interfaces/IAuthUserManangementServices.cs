using System.Threading.Tasks;
using FrutosMaipo.Feria.Service.Models;


namespace FrutosMaipo.Feria.Service.Infrastructure.Interfaces
{
    public interface IAuthUserManangementServices
    {
        Task<bool> CreateUser(Auth0UserModel userAdd);
    }
}
