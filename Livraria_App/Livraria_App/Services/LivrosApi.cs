using Livraria_App.Model;
using Newtonsoft.Json;
using Org.Apache.Http.Conn;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Livraria_App.Services
{
    public class LivrosApi
    {
        public const string URL = "https://repo-pi-gold.vercel.app/livros";

        private HttpClient GetClient() 
        { 
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }

        public async Task<List<Livro>> GetLivros()
        {
            HttpClient client = GetClient();

            //HttpResponseMessage response = await client.GetAsync(URL);
            var response = await client.GetAsync(URL);
            if(response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Livro>>(content);
            }
            return new List<Livro>();
        }

        public async Task<Livro> GetLivro(int Id)
        {
            String dados = URL + "?id=" + Id;

            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(dados);
            if(response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var livros = JsonConvert.DeserializeObject<List<Livro>>(content);
                if (livros.Count > 0) return livros[0];
                else new Livro();
            }
            return new Livro();
        }

        public async Task CreateLivro(Livro livro)
        {
            String dados = URL;
            string json = JsonConvert.SerializeObject(livro);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(dados, content);
        }

        public async Task UpDateLivro(Livro livro)
        {
            String dados = URL + "/" + livro.id;
            string json = JsonConvert.SerializeObject(livro);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(dados, content);
        }

        public async Task DeleteLivro(int Id)
        {
            String dados = URL + "/" + Id.ToString();
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.DeleteAsync(dados);
        }
    }
}
