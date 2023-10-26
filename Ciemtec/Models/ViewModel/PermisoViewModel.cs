using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_FND.Models.ViewModel
{
    public class PermisoViewModel
    {
        public int IdentificadorPermiso { get; set; }
        public string DetallePermiso { get; set; }
        public ModuloViewModel IdentificadorModuloNavigation { get; set; }
    }

    public class PermisoValueViewModel
    {
        public int IdentificadorPermiso { get; set; }
        public string DetallePermiso { get; set; }
        public ModuloIdViewModel IdentificadorModuloNavigation { get; set; }
    }

    public class RolPermisoDto
    {
        public int IdentificadorPermiso { get; set; }
        public bool ValorRolPermiso { get; set; }
    }

    public class PermisoByRol
    {
        public int Identificador_Permiso { get; set; }

        public string Detalle_Permiso { get; set; }

        public int Identificador_Modulo { get; set; }

        public bool Valor_Rol_Permiso { get; set; }

        public string Nombre_Rol { get; set; }
    }

    public class PermisoByRolDto
    {
        public int idPermiso { get; set; }

        public int valorPermiso { get; set; }

        public int modulo { get; set; }

        public string NombreRol { get; set; }
    }

    public class PermisoByRolApi
    {
        public int IdentificadorPermiso { get; set; }

        public bool ValorRolPermiso { get; set; }

        public string NombreRol { get; set; }
    }
}
