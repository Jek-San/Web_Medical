using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using ViewModel;
using ViewModels;

namespace Web_Medical_FE.Services
{
    public class RoleService
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration Configuration;
        private string RouteAPI = "";



        public RoleService(IConfiguration _Configuration)
        {
            this.Configuration = _Configuration;
            this.RouteAPI = this.Configuration["routeapi"];

        }

        public async Task<List<VMRole>> AllRole()
        {
            List<VMRole> listVariants = new List<VMRole>();
            string apiResponse = await client.GetStringAsync(RouteAPI +
                "api/MRoles");

            listVariants = JsonConvert.DeserializeObject<List<VMRole>>(apiResponse);

            return listVariants;
        }

    }
}
