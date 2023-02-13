using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Net;
using ViewModel;
using ViewModels;
using Web_Medical_FE.Services;

namespace Web_Medical_FE.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService authService;
        private readonly RoleService roleService;
        public AuthController(AuthService _authService,RoleService roleService )
        {
            this.authService= _authService;
            this.roleService= roleService;
        }
        VMResponse response = new VMResponse();

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

        public IActionResult Pendaftaran()
        {
            return PartialView();
        }

        public async Task<JsonResult> CheckEmail(string email)
        {
            bool isExist = await authService.CheckEmail(email);
            return Json(isExist);
        }

        [HttpGet]
        public async Task<IActionResult> SendOTP(string Email, int Case)
        {
            VMToken data = new VMToken();
            int otp = 0;
            Random rnd = new Random();
            otp = rnd.Next(100000, 999999);
            data.Token = otp.ToString();
            data.Email = Email;
            bool send = SendEmail(data, otp);
            if (send)
            {
            response = await authService.SendOTP(data, Case);

            }
            return Json(response);
        }

        public IActionResult ModalCheckOTP()
        {
            return PartialView();
        }
        public async Task<JsonResult> CheckOtp(int otp)
        {
            bool respon = await authService.CheckOtp(otp);
            return Json(respon);

        }
        public IActionResult ModalSetPassword()
        {
            return PartialView();
        }

        public async Task<IActionResult> ModalIsiData()
        {
            List<VMRole> listRole = await roleService.AllRole();

            ViewBag.ListRole = listRole;
            return PartialView();
        }





        public bool SendEmail(VMToken cs, int otp)
        {
            bool isSuccess = false;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;

            MailAddress from = new MailAddress("projectxaa@gmail.com", "MED.ID");

            MailAddress to = new MailAddress(cs.Email);

            MailMessage message = new MailMessage(from, to);

            message.Body = $"Hallo {cs.Email}, berikut adalah kode OTP mu \n{otp}\nSilahkaan gunakan kode tersebut untuk mendaftar";

            message.Subject = "OTP MEDID";
            NetworkCredential myCreds = new NetworkCredential("projectxaa@gmail.com", "awtnufofeaavdmlg");

            client.Credentials = myCreds;
            var userState = "SendingEmail";

            try
            {
                client.SendAsync(message, userState);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is:" + ex.ToString());
            }
            return isSuccess;
        }

    }
}
