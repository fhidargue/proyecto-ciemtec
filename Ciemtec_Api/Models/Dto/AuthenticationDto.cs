using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_Api.Models.Dto
{
    public class AuthenticationDto
    {
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
    }
    public class AuthenticationToken
    {
        public string Token { get; set; }
    }

    public class PrivilegiosResult
    {
        public string Variable_Permiso { get; set; }

        public bool Valor_Rol_Permiso { get; set; }
    }

    public class PrivilegiosDto
    {
        public int Identificador_Empleado { get; set; }

        public string Nombre_Modulo { get; set; }
    }
}
