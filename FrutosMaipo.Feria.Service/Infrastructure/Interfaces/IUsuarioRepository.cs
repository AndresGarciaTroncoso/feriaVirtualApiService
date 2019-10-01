using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrutosMaipo.Feria.Service.Models;

namespace FrutosMaipo.Feria.Service.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> DetalleUsuarioPorId(int idUsuario);
        Task<RolFuncionModel> ObtenerRolYFunciones(int idRol);
        Task<bool> CrearUsuarioDB(Auth0UserModel usuario);
    }
}
