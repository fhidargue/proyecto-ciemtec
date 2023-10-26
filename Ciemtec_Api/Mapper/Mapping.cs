using AutoMapper;
using Ciemtec_Api.Entities;
using Ciemtec_Api.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_Api.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<Rol, RolCreateDto>().ReverseMap();

            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoCreateDto>().ReverseMap();

            CreateMap<Modulo, ModuloDto>().ReverseMap();
            CreateMap<Permiso, PermisoDto>().ReverseMap();

            CreateMap<RolPermiso, RolPermisoDto>().ReverseMap();
        }
    }
}
