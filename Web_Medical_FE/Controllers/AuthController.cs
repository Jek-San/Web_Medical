using Microsoft.AspNetCore.Mvc;
using ViewModel;
using ViewModels;
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
            { return RedirectToAction("Index", "Home"); }
            return View(user);
        }
        
        public async Task<JsonResult> CheckEmailPassword(string Email, string Password)
        {
            VMUser dataparam = new VMUser();
            dataparam.Email = Email;
            dataparam.Password = Password;
            bool response = await authService.Check(dataparam);

            return Json(response);
        }
        public IActionResult Sukses()
        {
            return PartialView();
        }
    }
}
