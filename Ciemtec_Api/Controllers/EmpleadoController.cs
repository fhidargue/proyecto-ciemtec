using AutoMapper;
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

namespace Ciemtec_Api.Contempleadolers
{
    [Route("api/Empleado")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class EmpleadoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _context;


        public EmpleadoController(IMapper mapper, IUnitWork context)
        {
            _mapper = mapper;
            _context = context;
        }


        #region GetEmpleados
        /// <summary>
        /// Retorna todos los empleados del sistema
        /// </summary>
        /// <returns>EmpleadoDto</returns>
        [HttpGet(Name = "GetEmpleados")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmpleadoDto>))]
        [ProducesDefaultResponseType]
        public IActionResult GetEmpleados()
        {
            try
            {
                List<EmpleadoDto> empleadoDtos = new List<EmpleadoDto>();
                _context.Empleados.GetRolInEmpleado().ToList().ForEach(e => empleadoDtos.Add(_mapper.Map<EmpleadoDto>(e)));

                return Ok(empleadoDtos);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

        #endregion


        #region GetEmpleado
        /// <summary>
        /// Obtiene un empleado por su ID
        /// </summary>
        /// <param name="empleadoId"></param>
        /// <returns>EmpleadoDto</returns>
        [HttpGet("{empleadoId:int}", Name = "GetEmpleado")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpleadoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult GetEmpleado(int empleadoId)
        {
            try
            {
                Empleado empleado = _context.Empleados.GetRolInEmpleado(empleadoId);

                return (empleado == null) ? NotFound() : Ok(_mapper.Map<EmpleadoDto>(empleado));
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        #endregion


        #region CreateEmpleado
        /// <summary>
        /// Crea un empleado en el sistema
        /// </summary>
        /// <param name="empleadoCreateDto"></param>
        /// <returns>NoContent</returns>
        [HttpPost(Name = "CreateEmpleado")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateEmpleado([FromBody] EmpleadoCreateDto empleadoCreateDto)
        {
            try
            {
                if (empleadoCreateDto == null) return BadRequest(ModelState);

                if (_context.Empleados.ExistEmpleadoByCedula(empleadoCreateDto.CedulaEmpleado))
                {
                    ModelState.AddModelError("", "Cédula ya existente");
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                if (!_context.Roles.ExistRol(empleadoCreateDto.IdentificadorRol)) return NotFound();

                _context.Empleados.Add(_mapper.Map<Empleado>(empleadoCreateDto));

                if (!(_context.Complete() > 0))
                {
                    ModelState.AddModelError("", $"Algo mal sucedió guardando el objeto {empleadoCreateDto.NombreEmpleado}");
                    return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
                }

                return NoContent();

            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion


        #region UpdateEmpleado
        /// <summary>
        /// Actualiza un empleado en el sistema
        /// </summary>
        /// <param name="empleadoId"></param>
        /// <param name="empleadoDto"></param>
        /// <returns>NoContent</returns>
        [HttpPatch("{empleadoId:int}", Name = "UpdateEmpleado")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateEmpleado(int empleadoId, [FromBody] EmpleadoUpdateDto empleadoDto)
        {
            try
            {

                if (empleadoDto == null || empleadoId != empleadoDto.IdentificadorEmpleado) return BadRequest(ModelState);

                if (!_context.Empleados.ExistEmpleadoById(empleadoId)) return NotFound();

                if (!_context.Roles.ExistRol(empleadoDto.IdentificadorRol)) return NotFound();

                _context.Empleados.Update(_mapper.Map<Empleado>(empleadoDto));

                if (!(_context.Complete() > 0))
                {
                    ModelState.AddModelError("", $"Algo mal sucedió guardando el objeto {empleadoDto.NombreEmpleado}");
                    return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        #endregion


        #region DeleteEmpleado
        /// <summary>
        /// Elimina un empleado del sistema
        /// </summary>
        /// <param name="empleadoId"></param>
        /// <returns>NoContent</returns>
        [HttpDelete("{empleadoId:int}", Name = "DeleteEmpleado")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult DeleteEmpleado(int empleadoId)
        {
            try
            {
                if (!_context.Empleados.ExistEmpleadoById(empleadoId)) return NotFound();

                Empleado empleado = _context.Empleados.Get(empleadoId);

                _context.Empleados.Remove(empleado);

                if (!(_context.Complete() > 0))
                {
                    ModelState.AddModelError("", $"Algo mal sucedió guardando el objeto {empleado.NombreEmpleado}");
                    return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
                }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion
    }
}
