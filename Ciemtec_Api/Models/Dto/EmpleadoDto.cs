using Ciemtec_Api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_Api.Models.Dto
{
    public class EmpleadoDto
    {
        [Key]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Digite sólo números")]
        public int IdentificadorEmpleado { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Digite sólo números")]
        public string CedulaEmpleado { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string NombreEmpleado { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string ApellidoPaternoEmpleado { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string ApellidoMaternoEmpleado { get; set; }

        [Required]
        public string UsuarioEmpleado { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El correo es inválido")]
        public string CorreoEmpleado { get; set; }

        [Required]
        public string ContraseniaEmpleado { get; set; }


        public RolCreateDto IdentificadorRolNavigation { get; set; }
    }

    public class EmpleadoCreateDto
    {
        [Required]
        [RegularExpression("^\\d+$", ErrorMessage = "Digite sólo números")]
        public string CedulaEmpleado { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string NombreEmpleado { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string ApellidoPaternoEmpleado { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string ApellidoMaternoEmpleado { get; set; }

        [Required]
        public string UsuarioEmpleado { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El correo es inválido")]
        public string CorreoEmpleado { get; set; }

        [Required]
        public string ContraseniaEmpleado { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Digite sólo números")]
        public int IdentificadorRol { get; set; }
    }

    public class EmpleadoUpdateDto
    {
        [Key]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Digite sólo números")]
        public int IdentificadorEmpleado { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Digite sólo números")]
        public string CedulaEmpleado { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string NombreEmpleado { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string ApellidoPaternoEmpleado { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite sólo letras por favor")]
        public string ApellidoMaternoEmpleado { get; set; }

        [Required]
        public string UsuarioEmpleado { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El correo es inválido")]
        public string CorreoEmpleado { get; set; }

        [Required]
        public string ContraseniaEmpleado { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Digite sólo números")]
        public int IdentificadorRol { get; set; }
    }

}
