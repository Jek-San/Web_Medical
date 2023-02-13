using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using ViewModel;
using ViewModels;

namespace Web_Medical_FE.Services
{
    public class AuthService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration Configuration;
        private string RouteAPI = "";



        public AuthService(IConfiguration _Configuration)
        {
            this.Configuration = _Configuration;
            this.RouteAPI = this.Configuration["routeapi"];

        }


        [HttpGet]
        public async Task<bool> Login(string Email, string Password)
        {
            bool isLogin = true;
            string apiResponse = await client.GetStringAsync(RouteAPI + $"api/apiAuth/Login/{Email}/{Password}");
            isLogin = JsonConvert.DeserializeObject<bool>(apiResponse);

            return isLogin;



        }
        [HttpGet]
        public async Task<VMResponse> CheckEmailPassword(VMUser dataParam)
        {
            VMResponse vmResponse = null;
            string apiResponse = await client.GetStringAsync(RouteAPI + $"api/apiAuth/Check/{dataParam.Email}/{dataParam.Password}");
            vmResponse = JsonConvert.DeserializeObject<VMResponse>(apiResponse);
            return vmResponse;
        }
        [HttpGet]
        public async Task<bool> Check(VMUser dataParam)
        {
            
            string apiResponse = await client.GetStringAsync(RouteAPI + $"api/apiAuth/Login/{dataParam.Email}/{dataParam.Password}");
            bool respon = JsonConvert.DeserializeObject<bool>(apiResponse);
            return respon;
        }

        //check emailonly
        [HttpGet]
        public async Task<bool> CheckEmail(string email)
        {
            string apiResponse = await client.GetStringAsync(RouteAPI + $"api/apiAuth/CheckUserByEmail/{email}");
            bool respon = JsonConvert.DeserializeObject<bool>(apiResponse) ;
            return respon;
        }
        [HttpPost]
        public async Task<VMResponse> SendOTP(VMToken data, int Case)
        {
            VMResponse respon = new VMResponse();
            string json = JsonConvert.SerializeObject(data);


            StringContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var request = await client.PostAsync(RouteAPI + $"api/apiAuth/OTP/{Case}", content);

            if (request.IsSuccessStatusCode)
            {
                string apiResponse = await request.Content.ReadAsStringAsync();

                respon = JsonConvert.DeserializeObject<VMResponse>(apiResponse);

            }
            else
            {
                respon.Success = false;
                respon.Message = $"{request.StatusCode} : {request.ReasonPhrase}";
            }
            return respon;
        }

        [HttpGet]
        public async Task<bool> CheckOtp(int OTP)
        {
            bool isSuccess = false;
            string apiResponse = await client.GetStringAsync(RouteAPI + $"api/apiAuth/CheckOTP/{OTP.ToString()}");
            bool respon = JsonConvert.DeserializeObject<bool>(apiResponse);
            return respon;

        }
    }
}
