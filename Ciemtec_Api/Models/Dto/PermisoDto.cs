using Ciemtec_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_Api.Models.Dto
{
    public class PermisoDto
    {
        public int IdentificadorPermiso { get; set; }
        public string DetallePermiso { get; set; }
        public ModuloDto IdentificadorModuloNavigation { get; set; }
    }

    public class RolPermisoDto
    {
        public int IdentificadorPermiso { get; set; }
        public bool ValorRolPermiso { get; set; }
    }

    public class PR_GET_PERMISO_VALUE
    {
        public int Identificador_Permiso { get; set; }

        public string Detalle_Permiso { get; set; }

        public int Identificador_Modulo { get; set; }

        public bool Valor_Rol_Permiso { get; set; }

        public string Nombre_Rol { get; set; }
    }



}
