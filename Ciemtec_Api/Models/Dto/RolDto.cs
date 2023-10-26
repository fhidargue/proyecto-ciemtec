using Ciemtec_Api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_Api.Models.Dto
{
    public class RolDto
    {
        [Key]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Digite sólo números")]
        public int IdentificadorRol { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string NombreRol { get; set; }

    }
    public class RolCreateDto
    {
        public string NombreRol { get; set; }

        public int IdentificadorPermiso { get; set; }

        public bool ValorRolPermiso { get; set; }
    }

    public class ManejoRolDto
    {
        public int IdentificadorManejoRol { get; set; }
        public int IdentificadorRol { get; set; }
        public int IdentificadorPermiso { get; set; }
        public int IdentificadorModulo { get; set; }
    }
    public class ManejoRolValuesDto
    {
        public int ModuloCount { get; set; }

        public Rol Rol { get; set; }

        public List<Permiso> permisos { get; set; }
    }



}
