﻿using Newtonsoft.Json;
using ViewModel;

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

        

        public async Task<bool> Login(string Email, string Password)
        {
            bool isLogin = true;
            string apiResponse = await client.GetStringAsync(RouteAPI + $"api/apiAuth/Login/{Email}/{Password}");
            isLogin = JsonConvert.DeserializeObject<bool>(apiResponse);

            return isLogin;



        }
    }
}