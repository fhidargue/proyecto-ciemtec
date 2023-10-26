using System;
using System.Collections.Generic;

#nullable disable

namespace Ciemtec_Api.Entities
{
    public partial class Permiso
    {
        public Permiso()
        {
            RolPermisos = new HashSet<RolPermiso>();
        }

        public int IdentificadorPermiso { get; set; }
        public string DetallePermiso { get; set; }
        public string VariablePermiso { get; set; }
        public int IdentificadorModulo { get; set; }

        public virtual Modulo IdentificadorModuloNavigation { get; set; }
        public virtual ICollection<RolPermiso> RolPermisos { get; set; }
    }
}
