using AutoMapper;
using Ciemtec_Api.Entities;
using Ciemtec_FND.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_FND.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Empleado, EmpleadoViewModel>().ReverseMap();
            CreateMap<Empleado, EmpleadoCreateViewModel>().ReverseMap();

            CreateMap<RolViewModel, RolNameViewModel>().ReverseMap();
            CreateMap<Rol, RolViewModel>().ReverseMap();
            CreateMap<Rol, RolNameViewModel>().ReverseMap();


            CreateMap<Permiso, PermisoViewModel>().ReverseMap();
            CreateMap<Modulo, ModuloViewModel>().ReverseMap();

            CreateMap<PermisoViewModel, PermisoValueViewModel>().ReverseMap();
            CreateMap<ModuloViewModel, ModuloIdViewModel>().ReverseMap();

            CreateMap<RolPermiso, RolPermisoDto>().ReverseMap();

            CreateMap<PermisoByRolDto, PermisoByRolApi>().ReverseMap();
        }
    }
}
