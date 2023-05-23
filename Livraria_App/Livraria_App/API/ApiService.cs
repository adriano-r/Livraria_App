using Livraria_App.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Livraria_App.API
{
    internal class ApiService
    {
        public const string URL = "https://reqres.in/";

        public static async Task<List<User>> ObterUser()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = URL + "api/users";
                string response = await client.GetStringAsync(url);
                List<User> usuario = JsonConvert.DeserializeObject<List<User>>(response);
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
