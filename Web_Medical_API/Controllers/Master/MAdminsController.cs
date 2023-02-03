using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewModels;
using Web_Medical_API.models;

namespace Web_Medical_API.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class MAdminsController : ControllerBase
    {
        public readonly medicalContext db;
        private VMResponse response = new VMResponse();


        public MAdminsController(medicalContext _db)
        {
            this.db = _db;
        }

        [HttpGet("GetAllFasKes")]
        public List<MAdmin> AllDataKategoriFaskes()
        {
            List<MAdmin> admin = db.MAdmins.Where(a => a.IsDelete == false).ToList();

            return admin;
        }
        [HttpGet("CheckAdminById/{id}")]
        public bool CheckAdminById(long id)
        {
            MAdmin admin = new MAdmin();
            admin = db.MAdmins.Where(a => a.Id == id && a.IsDelete == false).FirstOrDefault();

            if (admin == null)
            {
                return false;
            }

            return true;
        }

        [HttpGet("GetAdminById/{id}")]
        public MAdmin GetAdminById(int id)
        {
            MAdmin admin = new MAdmin();

            admin = db.MAdmins.Where(a => a.Id == id).FirstOrDefault();

            return admin;

        }
        [HttpPost("AddAdmin")]
        public VMResponse AddAdmin(MAdmin input)
        {
            input.CreatedOn = DateTime.Now;
            input.CreatedBy = 1;
            input.IsDelete = false;

            try
            {
                db.Add(input);
                db.SaveChanges();

                response.Success = true;
                response.Message = "Data Insert Success";

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Input Failed with " + e;
            }

            return response;
        }
        [HttpPut("EditAdmin")]
        public VMResponse EditAdmin(MAdmin input)
        {
            MAdmin res = db.MAdmins.Where(a => a.Id == input.Id).FirstOrDefault();

            if (res == null)
            {
                response.Success = false;
                response.Message = "Data Not Found";
                return response;
            }

            res.Id = input.Id;
            res.ModifiedOn = DateTime.Now;
            res.ModifiedBy = 1;

            try
            {
                db.Update(res);
                db.SaveChanges();

                response.Success = true;
                response.Message = "Edit Succes";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Edit Failed " + e;
            }

            return response;
        }





        [HttpPut("RemoveAdmin")]
        public VMResponse RemoveAdmin(MAdmin input)
        {
            //VMKategoriFasKes test = new VMKategoriFasKes();
            //test = (from user in db.MUsers
            //        join bio in db.MBiodata on user.BiodataId equals bio.Id
            //        wh
            //        )
            MAdmin res = db.MAdmins.Where(a => a.Id == input.Id).FirstOrDefault();
            if (res == null)
            {
                response.Success = false;
                response.Message = "Data Not Found";
                return response;
            }
            res.DeletedOn = DateTime.Now;
            res.DeletedBy = 1;
            res.IsDelete = true;
            try
            {
                db.Update(res);
                db.SaveChanges();

                response.Success = true;
                response.Message = "Edit Succes";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Edit Failed " + e;
            }

            return response;



        }
        ////buat dapetin id user
        //[HttpGet("GetUserById/{id}")]
        //public MUser GetUserById(int id)
        //{
        //    MUser user = new MUser();

        //    user = db.MUsers.Where(a => a.Id == id).FirstOrDefault();

        //    return user;

        //}
    }
}
