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
    public class ServicesController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISendEmailService _sendEmailServices;

        public ServicesController(IUsuarioRepository usuarioRepository, ISendEmailService sendEmailServices)
        {
            _usuarioRepository = usuarioRepository;
            _sendEmailServices = sendEmailServices;
        }

        [HttpPost]
        [Route("SendEmailReport")]
        public async Task<IActionResult> CreateUser([FromBody] string destinationEmail)
        {
            if (await _sendEmailServices.SendEmail(destinationEmail))
            {
                return Ok(true);
            }
            else
                return Ok(false);
        }

    }
}