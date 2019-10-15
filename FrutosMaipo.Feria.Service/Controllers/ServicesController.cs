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
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SendEmailReport([FromBody] SendEmailParameterModel destinationEmail)
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