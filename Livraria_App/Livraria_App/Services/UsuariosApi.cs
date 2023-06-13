using Livraria_App.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Livraria_App.Services
{
    public class UsuariosApi
    {
        const String URL = "https://repo-pi-gold.vercel.app/usuarios";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                String content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Usuario>>(content);
            }
            return new List<Usuario>();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            String dados = URL + "?id=" + id;

            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(dados);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content?.ReadAsStringAsync();
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);
                if (usuarios.Count > 0) return usuarios[0];
                else new Usuario();
            }
            return new Usuario();
        }

        public async Task CreateUsuario(Usuario usuario)
        {
            String dados = URL;
            string json = JsonConvert.SerializeObject(usuario);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(dados, content);
        }

        public async Task UpDateUsuario(Usuario usuario)
        {
            String dados = URL + "/" + usuario.id;

            string json = JsonConvert.SerializeObject(usuario);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(dados, content);
        }

        public async Task DeleteUsuario(int id)
        {
            String dados = URL + "/" + id.ToString();
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.DeleteAsync(dados);
        }
    }
}


