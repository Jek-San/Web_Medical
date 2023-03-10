using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using ViewModel;
using ViewModels;
using Web_Medical_API.models;

namespace Web_Medical_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class apiAuthController : ControllerBase
    {
        public readonly medicalContext db;
        private VMResponse response = new VMResponse();

        public apiAuthController(medicalContext db)
        {
            this.db = db;
        }

        [HttpGet("GetAllUser")]
        public List<MUser> GetUsers()
        {
            List<MUser> user = new List<MUser>();
            user = db.MUsers.Where(a => a.IsDelete == false).ToList();
            return user;
        }
        [HttpPost("PostUser")]
        public VMResponse PostUser(MUser data)
        {
            data.IsDelete = false;
            data.CreatedOn = DateTime.Now;
            data.CreatedBy = 1;
            try
            {
                db.Add(data);
                db.SaveChanges();
                response.Success = true;
                response.Message = "Post User Is Success";

            }
            catch (Exception e)
            {

                response.Success = false;
                response.Message = "Post data is Failed with exception " + e;
            }
            return response;
        }

        [HttpPut("PutUser/{id}")]
        public VMResponse PutUser(MUser data)
        {
            data.IsDelete = false;
            data.ModifiedOn = DateTime.Now;
            data.ModifiedBy = 1;
            try
            {
                db.Update(data);
                db.SaveChanges();
                response.Success = true;
                response.Message = "Put data is Success";

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Edit data is Failde with exeption" + e;
            }

            return response;
        }

        [HttpGet("Login/{email}/{password}")]
        public bool Login(string email, string password)
        {
            MUser user = new MUser();
            bool isLogin = true;
            user = db.MUsers.Where(i => i.Password == password && i.Email == email).FirstOrDefault();

            if (user == null)
            {
                isLogin = false;
            }
            return isLogin;
        }
        //Check Email Only
        [HttpGet("CheckUserByEmail/{email}")]
        public bool CheckUserByEmail(string email)
        {
            MUser user = new MUser();
            user = db.MUsers.Where(a => a.Email == email && a.IsDelete == false).FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            return true;
        }
        [HttpGet("CheckOTp/{OTP}")]
        public bool CheckOTP(string OTP)
        {
            TToken token = new TToken();
            token = db.TTokens.Where(a => a.Token == OTP && a.IsExpired == false).FirstOrDefault();

            if (token == null)
            {
                return false;
            }

            return true;
        }

        [HttpGet("Check/{email}/{password}")]
        public VMResponse CheckEmailPassword(string Email, string Password)
        {

            VMResponse response = new VMResponse();
            response.Success = true;
            MUser user = new MUser();
            user = db.MUsers.Where(a => a.Email == Email).FirstOrDefault();
            if (user == null)
            {
                response.Success = false;
                response.Message = "Email tidak ditemukan";
                return response;
            }
            if (response.Success)
            {
                user = db.MUsers.Where(a => a.Password == Password & a.Email == Email).FirstOrDefault();
                if (user == null)
                {
                    response.Success = false;
                    response.Message = "Password anda salah";
                }
            }
            return response;
        }

        [HttpPost("OTP/{Case}")]
        public VMResponse OTP(TToken data, int Case)
        {

            TToken cs = db.TTokens.Where(a => a.Email == data.Email).OrderByDescending(a => a.CreateOn).FirstOrDefault();
            if (cs == null || DateTime.Now > cs.ExpiredOn || cs.IsExpired == true)
            {
                data.CreateOn = DateTime.Now;
                data.ExpiredOn = DateTime.Now.AddMinutes(10);
                data.CreateBy = 1;
                data.IsExpired = (DateTime.Now > data.ExpiredOn) ? true : false;
                data.IsDelete = false;
                if (Case == 1)
                {
                    data.UsedFor = "Daftar";
                }
                else if (Case == 2)
                {
                    data.UsedFor = "Lupa Password";
                }
                else if (Case == 3)
                {
                    data.UsedFor = "Ganti E-mail";
                }
                try
                {
                    db.Add(data);
                    db.SaveChanges();

                    response.Message = "token berhasil ditambah";
                }
                catch (Exception e)
                {
                    response.Success= false;
                    response.Message = "Failed saved : " + e.Message;

                }
            }
            return response;
        }

    }
}
