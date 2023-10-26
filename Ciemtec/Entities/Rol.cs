using System;
using System.Collections.Generic;

#nullable disable

namespace Ciemtec_Api.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            Empleados = new HashSet<Empleado>();
            RolPermisos = new HashSet<RolPermiso>();
        }

        public int IdentificadorRol { get; set; }
        public string NombreRol { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<RolPermiso> RolPermisos { get; set; }
    }
}
