﻿using System;
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

        [HttpGet]
        [Route("ObtenerRoles")]
        [ProducesResponseType(typeof(RolModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerRoles()
        {
            IList<RolModel> rolList = await _usuarioRepository.ObtenerRoles();
            if (rolList != null)
            {
                return Ok(rolList);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpGet]
        [Route("ObtenerClientes/{idRol}")]
        [ProducesResponseType(typeof(ClienteModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerClientes(int idRol)
        {
            IList<ClienteModel> clienteList = await _usuarioRepository.ObtenerClientes(idRol);
            if (clienteList != null)
            {
                return Ok(clienteList);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(ClienteModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            IList<UsuarioModel> usuarioList = await _usuarioRepository.ObtenerUsuarios();
            if (usuarioList != null)
            {
                return Ok(usuarioList);
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

        [HttpPost]
        [Route("Update")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ActualizarUsuario([FromBody] Auth0UserModel usuario)
        {
            if (await _usuarioRepository.ActualizarUsuario(usuario) != false)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }
    }
}