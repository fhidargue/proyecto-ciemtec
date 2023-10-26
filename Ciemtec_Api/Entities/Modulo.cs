using System;
using System.Collections.Generic;

#nullable disable

namespace Ciemtec_Api.Entities
{
    public partial class Modulo
    {
        public Modulo()
        {
            Permisos = new HashSet<Permiso>();
        }

        public int IdentificadorModulo { get; set; }
        public string NombreModulo { get; set; }
        public string UrlModulo { get; set; }

        public virtual ICollection<Permiso> Permisos { get; set; }
    }
}
