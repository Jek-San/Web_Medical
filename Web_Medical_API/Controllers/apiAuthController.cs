using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                response.Success=false;
                response.Message= "Edit data is Failde with exeption"+ e;
            }

            return response;
        }

        [HttpGet("Login/{email}/{password}")]
        public bool Login(string email, string password)
        {
            MUser user = new MUser();
            user = db.MUsers.Where(i => i.Password == password && i.Email == email).FirstOrDefault();
            
            if (user == null)
            {
                return false;
            }    
            return true;
        }

    }
}
