using System;
using System.Collections.Generic;

#nullable disable

namespace Ciemtec_Api.Entities
{
    public partial class Empleado
    {
        public int IdentificadorEmpleado { get; set; }
        public string CedulaEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoPaternoEmpleado { get; set; }
        public string ApellidoMaternoEmpleado { get; set; }
        public string UsuarioEmpleado { get; set; }
        public string CorreoEmpleado { get; set; }
        public string ContraseniaEmpleado { get; set; }
        public DateTime? FechaRegistrado { get; set; }
        public int IdentificadorRol { get; set; }

        public virtual Rol IdentificadorRolNavigation { get; set; }
    }
}
