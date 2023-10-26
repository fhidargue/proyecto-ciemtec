using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciemtec_FND.Models.ViewModel
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}
