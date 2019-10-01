using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrutosMaipo.Feria.Service.Models;
using FrutosMaipo.Feria.Service.Infrastructure.Interfaces;
using System.Net;

namespace FrutosMaipo.Feria.Service.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthUserManangementServices _authUserManangementServices;

        public UsuarioController(IUsuarioRepository usuarioRepository, IAuthUserManangementServices authUserManangementServices)
        {
            _usuarioRepository = usuarioRepository;
            _authUserManangementServices = authUserManangementServices;
        }

        [HttpGet]
        [Route("GetById/{idUsuario}")]
        [ProducesResponseType(typeof(UserData), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UsuarioPorId(int idUsuario)
        {
            UserData response = new UserData();
            UsuarioModel usuario = await _usuarioRepository.DetalleUsuarioPorId(idUsuario);
            RolFuncionModel rolFunciones = null;
            if (usuario != null)
            {
                var idRol = usuario.Rol.GetValueOrDefault();
                rolFunciones = await _usuarioRepository.ObtenerRolYFunciones(idRol);
                response.usuario = usuario;
                response.rolFunciones = rolFunciones;
                return Ok(response);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] Auth0UserModel UserAdd)
        {
            if (await _authUserManangementServices.CreateUser(UserAdd))
            {
                if(await _usuarioRepository.CrearUsuarioDB(UserAdd))
                {
                    return Ok(true);
                }else
                {
                    return Ok(false);
                }
            }
            else
                return Ok(false);
        }
    }
}