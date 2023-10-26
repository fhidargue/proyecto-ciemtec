using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_FND.Models.Config
{
    public static class Static
    {
        public static string BaseUrl = "https://localhost:44388/";

        public static string Control = BaseUrl + "api/Empleado";

        public static string Equipo = BaseUrl + "api/Equipo";

        public static string Autenticacionm = BaseUrl + "api/Authentication";

        public static string Rol = BaseUrl + "api/Rol";
    }
}
