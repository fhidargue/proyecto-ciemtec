using Ciemtec_Api.Entities;
using Ciemtec_Api.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUnitWork _context;

        public AuthenticationController(IUnitWork context)
        {
            _context = context;
        }

        [HttpPost("Authentication")]
        public IActionResult Authentication([FromBody] AuthenticationDto authentication)
        {
            try
            {
                if (string.IsNullOrEmpty(authentication.Usuario) || string.IsNullOrEmpty(authentication.Contrasenia)) return BadRequest();

                AuthenticationToken token = _context.Permisos.Authentication(authentication);

                return (token == null && !(string.IsNullOrEmpty(token.Token))) ? BadRequest() : Ok(token.Token);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("IsLogged")]
        [Authorize]
        public IActionResult IsLogged()
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        [HttpPost("ValidateModulo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PrivilegiosResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult ValidateModulo([FromBody] PrivilegiosDto privilegio)
        {
            try
            {
                if (privilegio == null) return BadRequest();

                List<PrivilegiosResult> privilegios = _context.Permisos.ValidateModulo(privilegio).ToList();

                return (privilegios == null) ? NotFound() : (IActionResult)Ok(privilegios);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        [HttpGet("{empleadoId:int}", Name = "ValidateAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PrivilegiosResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult ValidateAll(int empleadoId)
        {
            try
            {
                if (empleadoId == 0) return BadRequest();

                List<PrivilegiosResult> privilegios = _context.Permisos.ValidateAll(empleadoId).ToList();

                return (privilegios == null) ? NotFound() : (IActionResult)Ok(privilegios);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
