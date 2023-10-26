using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_FND.Models.ViewModel
{
    public class RolViewModel
    {
        [Key]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Digite sólo números")]
        public int IdentificadorRol { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string NombreRol { get; set; }

    }

    public class RolNameViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string NombreRol { get; set; }
    }

    public class RolCreateViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string NombreRol { get; set; }

        public List<RolPermisoDto> Permisos { get; set; }
    }
}
