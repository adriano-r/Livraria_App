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
        public const string URL = "http://localhost:3000/";

        public static async Task<List<Usuario>> ObterUser()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = URL + "usuario";
                string response = await client.GetStringAsync(url);
                List<Usuario> usuario = JsonConvert.DeserializeObject<List<Usuario>>(response);
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
