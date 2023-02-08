using Microsoft.AspNetCore.Mvc;
using ViewModel;
using Web_Medical_FE.Services;

namespace Web_Medical_FE.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService authService;
        public AuthController(AuthService _authService)
        {
            this.authService= _authService;
        }

        public IActionResult Index()
        {
            
            return PartialView();
        }
        public async Task<IActionResult> Login(VMUser user)
        {
            string Name = user.Email;
            string Password = user.Password;
            bool isLigin = await authService.Login(Name, Password);

            if (isLigin==true) 
            { return View("Index","Home"); }
            return RedirectToAction("Index");

        }
    }
}
