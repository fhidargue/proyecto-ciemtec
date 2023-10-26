
using Ciemtec_FND.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Ciemtec.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SigningIn(UserViewModel user)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
