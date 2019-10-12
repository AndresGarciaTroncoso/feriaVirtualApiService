using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FrutosMaipo.Feria.Service.Infrastructure.Interfaces;
using FrutosMaipo.Feria.Service.Infrastructure.Entities;
using FrutosMaipo.Feria.Service.Models;

namespace FrutosMaipo.Feria.Service.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FMaipoBDContext _context;

        public UsuarioRepository(FMaipoBDContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearUsuarioDB(Auth0UserModel usuario)
        {
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.Rut = usuario.Rut;
            nuevoUsuario.Dv = usuario.Dv;
            nuevoUsuario.NombreCompleto = usuario.NombreCompleto;
            nuevoUsuario.Email = usuario.Email;
            nuevoUsuario.Vigencia = usuario.Vigencia;
            nuevoUsuario.Rol = usuario.Rol;
            await _context.Usuario.AddAsync(nuevoUsuario);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<UsuarioModel> DetalleUsuarioPorId(int idUsuario)
        {
            UsuarioModel usuario = null;
            try
            {
                Usuario usuarioEntity = await _context.Usuario.FirstOrDefaultAsync(a => a.Rut == idUsuario);
                if (usuarioEntity != null)
                {
                    usuario = new UsuarioModel
                    {
                        Rut = usuarioEntity.Rut,
                        Dv = usuarioEntity.Dv,
                        Rol = usuarioEntity.Rol,
                        NombreCompleto = usuarioEntity.NombreCompleto,
                        Email = usuarioEntity.Email,
                        Vigencia = usuarioEntity.Vigencia,
                    };
                    return usuario;
                }
                else { return usuario; }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<ClienteModel>> ObtenerClientes(int idRol)
        {
            IList<ClienteModel> clienteList = new List<ClienteModel>();
            ClienteModel clienteModel = null;
            try
            {
                var usuarioResult = await _context.Usuario.Where(x => x.Rol == idRol).ToListAsync();
                foreach (var item in usuarioResult)
                {
                    clienteModel = new ClienteModel()
                    {
                        idCliente = item.Rut,
                        nombreCliente = item.NombreCompleto
                    };
                    clienteList.Add(clienteModel);
                }
                return clienteList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IList<RolModel>> ObtenerRoles()
        {
            IList<RolModel> rolList = new List<RolModel>();
            RolModel rolModel = null;
            try
            {
                var rolResult = await _context.Rol.ToListAsync();
                foreach (var item in rolResult)
                {
                    rolModel = new RolModel()
                    {
                        IdRol = item.IdRol,
                        Descripcion = item.Descripcion
                    };
                    rolList.Add(rolModel);
                }
                return rolList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<RolFuncionModel> ObtenerRolYFunciones(int idRol)
        {
            RolFuncionModel rolFuncion = null;
            List<FuncionModel> funciones = new List<FuncionModel>();
            FuncionModel funcionModel = null;
            try
            {
                Rol rolEntity = await _context.Rol.FirstOrDefaultAsync( a => a.IdRol == idRol);

                if (rolEntity != null)
                {
                    //List<FuncionRol> funcionRolEntity = await _context.FuncionRol.Where(x => x.Rol == idRol).ToListAsync();

                    List<FuncionRol> aux = await _context.FuncionRol
                        .Include(a => a.FuncionNavigation)
                        .Include("FuncionNavigation")
                        .Where(c => c.Rol == idRol).ToListAsync();

                    foreach (var funcion in aux)
                    {
                        funcionModel = new FuncionModel()
                        {
                            FuncionId= (int)funcion.FuncionNavigation.IdFuncion,
                            FuncionNombre = funcion.FuncionNavigation.TipoFuncion,
                            Descripcion= funcion.FuncionNavigation.Descripcion
                        };

                        funciones.Add(funcionModel);
                    }

                    rolFuncion = new RolFuncionModel()
                    {
                        Funciones = funciones,
                        IdRole = rolEntity.IdRol,
                        DescriptionRole = rolEntity.Descripcion
                    };
                    return rolFuncion;
                }
                else
                {
                    return rolFuncion;
                }
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                var e = ex.Message;
                throw;
            }
        }
    }


}
