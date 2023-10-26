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

namespace Ciemtec_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class RolController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _context;

        public RolController(IMapper mapper, IUnitWork context)
        {
            _context = context;
            _mapper = mapper;

        }


        #region GetRoles

        /// <summary>
        /// Obtiene todos los roles
        /// </summary>
        /// <returns>Rol</returns>
        [HttpGet(Name = "GetRoles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RolDto>))]
        [ProducesDefaultResponseType]
        public IActionResult GetRoles()
        {
            try
            {
                List<RolDto> rolDtos = new List<RolDto>();
                _context.Roles.GetAll().ToList().ForEach(r => rolDtos.Add(_mapper.Map<RolDto>(r)));
                return Ok(rolDtos);

            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }
        #endregion


        #region GetRol
        /// <summary>
        /// Obtiene un Rol por medio de su ID
        /// </summary>
        /// <param name="rolId"></param>
        /// <returns></returns>
        [HttpGet("{rolId:int}", Name = "GetRol")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RolDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult GetRol(int rolId)
        {
            try
            {
                Rol rol = _context.Roles.Get(rolId);
                return (rol == null) ? NotFound() : Ok(_mapper.Map<RolDto>(rol));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion


        #region CreateRol
        /// <summary>
        /// Crea un Rol
        /// </summary>
        /// <param name="rolCreateDto"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateRol")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateRol([FromBody] List<RolCreateDto> rolCreateDto)
        {
            try
            {
                if (rolCreateDto == null) return BadRequest(ModelState);

                string nombre = null;

                rolCreateDto.ToList().ForEach(r =>
                {
                    if (r.NombreRol != null) nombre = r.NombreRol;

                });


                if (_context.Roles.ExistRol(nombre))
                {
                    ModelState.AddModelError("", "Rol Inválido");
                    return StatusCode(StatusCodes.Status404NotFound, ModelState);
                }

                RolDto rolNuevo = new RolDto
                {
                    NombreRol = nombre
                };

                _context.Roles.Add(_mapper.Map<Rol>(rolNuevo));

                if (!(_context.Complete() > 0))
                {
                    ModelState.AddModelError("", $"Algo mal sucedió guardando el objeto {nombre}");
                    return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
                }
                else
                {
                    Rol rol = _context.Roles.GetRolByName(nombre);

                    _context.Complete();

                    List<RolPermiso> rolPermisos = new List<RolPermiso>();

                    rolCreateDto.ToList().ForEach(p => rolPermisos.Add(
                        new RolPermiso
                        {
                            IdentificadorPermiso = p.IdentificadorPermiso,
                            IdentificadorRol = rol.IdentificadorRol,
                            ValorRolPermiso = p.ValorRolPermiso
                        }));

                    rolPermisos.ToList().ForEach(r =>
                    {
                        if (r.IdentificadorPermiso != 0) _context.RolPermisos.Update(r);

                    });
                    _context.Complete();
                }
                return StatusCode(StatusCodes.Status204NoContent, ModelState);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                _context.Dispose();
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion


        #region UpdateRol
        /// <summary>
        /// Actualiza un Rol
        /// </summary>
        /// <param name="rolId"></param>
        /// <param name="rolDto"></param>
        /// <returns></returns>
        [HttpPatch("{rolId:int}", Name = "UpdateRol")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateRol(int rolId, [FromBody] RolDto rolDto)
        {
            try
            {
                if (rolDto == null || rolId != rolDto.IdentificadorRol) return BadRequest(ModelState);


                if (!_context.Roles.ExistRol(rolId))
                {
                    ModelState.AddModelError("", "Rol Inválido");
                    return StatusCode(StatusCodes.Status404NotFound, ModelState);
                }

                if (!_context.Roles.ValidateRolName(rolId, rolDto.NombreRol))
                {
                    if (_context.Roles.ExistRol(rolDto.NombreRol))
                    {
                        ModelState.AddModelError("", "Rol Inválido");
                        return StatusCode(StatusCodes.Status404NotFound, ModelState);
                    }
                }


                _context.Roles.Update(_mapper.Map<Rol>(rolDto));


                if (!(_context.Complete() > 0))
                {
                    ModelState.AddModelError("", $"Algo mal sucedió guardando el objeto {rolDto.NombreRol}");
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


        #region DeleteRol
        /// <summary>
        /// Elimina un Rol
        /// </summary>
        /// <param name="rolId"></param>
        /// <returns></returns>
        [HttpDelete("{rolId:int}", Name = "DeleteRol")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult DeleteRol(int rolId)
        {
            try
            {
                if (!_context.Roles.ExistRol(rolId)) return NotFound();

                Rol rol = _context.Roles.Get(rolId);

                _context.Roles.Remove(rol);

                if (!(_context.Complete() > 0))
                {
                    ModelState.AddModelError("", $"Algo mal sucedió guardando el objeto {rol.NombreRol}");
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

        [HttpGet("GetPermisos")]
        public IActionResult GetPermisoModulo()
        {

            List<Permiso> listPermiso = _context.Permisos.GetPermisos().ToList();

            List<PermisoDto> listPermisoDto = new List<PermisoDto>();

            listPermiso.ToList().ForEach(l => listPermisoDto.Add(_mapper.Map<PermisoDto>(l)));

            return Ok(listPermisoDto);
        }



        [HttpGet("GetPermisosByRol/{rolId:int}")]
        public IActionResult GetPermisosByRol(int rolId)
        {

            List<PR_GET_PERMISO_VALUE> listPermiso = _context.Permisos.GetPermisosByRol(rolId).ToList();

            return Ok(listPermiso);
        }
    }
}
