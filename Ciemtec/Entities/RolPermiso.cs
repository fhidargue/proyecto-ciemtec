using System;
using System.Collections.Generic;

#nullable disable

namespace Ciemtec_Api.Entities
{
    public partial class RolPermiso
    {
        public int IdentificadorRol { get; set; }
        public int IdentificadorPermiso { get; set; }
        public bool ValorRolPermiso { get; set; }

        public virtual Permiso IdentificadorPermisoNavigation { get; set; }
        public virtual Rol IdentificadorRolNavigation { get; set; }
    }
}
