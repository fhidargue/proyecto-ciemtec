using AutoMapper;
using Ciemtec_Api.Entities;
using Ciemtec_FND.Models.Config;
using Ciemtec_FND.Models.ViewModel;
using Ciemtec_FND.Pattern.UnitWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_FND.Controllers
{
    public class ControlController : Controller
    {
        private readonly IUnitWork _context;
        private readonly IMapper _mapper;

        public ControlController(IUnitWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        #region Empleado
        public async Task<IActionResult> ControlIndex()
        {
            List<Empleado> empleados = (List<Empleado>)await _context.Empleados.GetAllAsync(Static.Control);
            List<EmpleadoViewModel> empleadosVM = new List<EmpleadoViewModel>();
            empleados.ToList().ForEach(e => empleadosVM.Add(_mapper.Map<EmpleadoViewModel>(e)));
            return View(empleadosVM);
        }

        [HttpGet("EditarPersonal/{id:int}")]
        public async Task<IActionResult> EditarPersonal(int id)
        {
            Empleado empleado = await _context.Empleados.GetAsync(Static.Control, id);

            return View(_mapper.Map<EmpleadoViewModel>(empleado));
        }


        [HttpPost("CreateEmpleado")]
        public async Task<IActionResult> CrearEmpleado(EmpleadoCreateViewModel empleado)
        {
            if (await _context.Empleados.CreateAsync(Static.Control, _mapper.Map<Empleado>(empleado)))
            {
                return RedirectToAction("ControlIndex", "Control");
            }
            else
            {
                return RedirectToAction("ControlIndex", "Control");
            }
        }

        public async Task<IActionResult> CrearPersonal()
        {
            EmpleadoCreateViewModel empleado = new EmpleadoCreateViewModel();
            empleado.Roles = await GetRoles();
            return View(empleado);
        }


        #endregion

        #region Rol
        public async Task<IActionResult> RolesIndex()
        {
            List<Rol> roles = await GetRoles();
            List<RolViewModel> rolesVM = new List<RolViewModel>();
            roles.ToList().ForEach(e => rolesVM.Add(_mapper.Map<RolViewModel>(e)));
            return View(rolesVM);
        }


        [HttpGet("EditarRoles/{rolId:int}")]
        public IActionResult EditarRoles(int rolId)
        {
            TempData["editarRolId"] = rolId;
            return View();
        }


        [HttpPost("EditarRolData")]
        public async Task<IActionResult> EditarRolData()
        {
            int rolId = (int)TempData["editarRolId"];
            List<PermisoByRol> permisos = (List<PermisoByRol>)await _context.Roles.GetPermisosByRol(rolId, Static.Rol);
            return Json(permisos);
        }



        [HttpPost("CrearRol")]
        public async Task<IActionResult> CrearRol(string permisos)
        {
            List<PermisoByRolDto> permiso;

            permiso = (List<PermisoByRolDto>)JsonConvert.DeserializeObject<IEnumerable<PermisoByRolDto>>(permisos);

            List<PermisoByRolApi> temp = new List<PermisoByRolApi>();

            permiso.ToList().ForEach(r =>
            {
                temp.Add(new PermisoByRolApi
                {
                    IdentificadorPermiso = r.idPermiso,
                    NombreRol = r.NombreRol,
                    ValorRolPermiso = Convert.ToBoolean(r.valorPermiso)

                });
            });

            bool data = await _context.Roles.CreateRolPermisos(temp, Static.Rol);

            if (data)
            {
                return Json("True");
            }
            else
            {
                return Json(null);
            }
        }


        [HttpPost("GetPermisoByModulo")]
        public async Task<IActionResult> GetPermisoByModulo()
        {
            List<PermisoViewModel> permisos = (List<PermisoViewModel>)await _context.Roles.GetPermisos(Static.Rol);
            return Json(permisos);
        }

        private async Task<List<Rol>> GetRoles()
        {
            List<Rol> roles = (List<Rol>)await _context.Roles.GetAllAsync(Static.Rol);
            return roles;
        }


        #endregion
    }
}
