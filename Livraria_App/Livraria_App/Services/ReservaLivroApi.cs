using Livraria_App.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Livraria_App.Services
{
    public class ReservaLivroApi
    {
        const String URL = "https://repo-pi-gold.vercel.app/reservados";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }

        public async Task<List<ReservaLivro>> GetReservas()
        {
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode)
            {
                String content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ReservaLivro>>(content);
            }
            return new List<ReservaLivro>();
        }

        public async Task<ReservaLivro> GetReserva(int id)
        {
            String dados = URL + "?id=" + id;

            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(dados);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content?.ReadAsStringAsync();
                var reservas = JsonConvert.DeserializeObject<List<ReservaLivro>>(content);
                if (reservas.Count > 0) return reservas[0];
                else new ReservaLivro();
            }
            return new ReservaLivro();
        }

        public async Task CreateReserva(ReservaLivro reserva)
        {
            String dados = URL;
            string json = JsonConvert.SerializeObject(reserva);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(dados, content);
        }

        public async Task UpDateReserva(ReservaLivro reserva)
        {
            String dados = URL + "/" + reserva.id;

            string json = JsonConvert.SerializeObject(reserva);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(dados, content);
        }

        public async Task DeleteReserva(int id)
        {
            String dados = URL + "/" + id.ToString();
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.DeleteAsync(dados);
        }
    }
}

