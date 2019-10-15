using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrutosMaipo.Feria.Service.Models;

namespace FrutosMaipo.Feria.Service.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> DetalleUsuarioPorId(int idUsuario);
        Task<IList<UsuarioModel>> ObtenerUsuarios();
        Task<RolFuncionModel> ObtenerRolYFunciones(int idRol);
        Task<bool> CrearUsuarioDB(Auth0UserModel usuario);
        Task<IList<RolModel>> ObtenerRoles();
        Task<IList<ClienteModel>> ObtenerClientes(int idRol);
        Task<bool> ActualizarUsuario(Auth0UserModel usuario);
    }
}
