using Livraria_App.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Livraria_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaUsuarios : ContentPage
    {
        public List<Usuario> Usuarios { get; set; }

        public ListaUsuarios()
        {
            InitializeComponent();

            LoadUsuarios();
        }

        private async void LoadUsuarios()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://repo-pi-gold.vercel.app/api/usuarios");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);

                    foreach (var usuario in usuarios)
                    {
                        Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Nome}, Sobrenome: {usuario.Sobrenome}, Email: {usuario.Email}, Avatar: {usuario.Avatar}");
                    }
                    UsuariosListView.ItemsSource = usuarios;
                }
                else
                {
                    // Handle unsuccessful response
                    await DisplayAlert("Error", "Failed to retrieve users", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                await DisplayAlert("Error", $"Failed to load users: {ex.Message}", "OK");
            }
        }

        private void EditarButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var id = (int)button.CommandParameter;
            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario != null)
            {
                DisplayAlert("Editar", $"Editar usuário com ID {usuario.Id}", "OK");
            }
        }

        private void RemoverButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var id = (int)button.CommandParameter;
            var usuario = Usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario != null)
            {
                Usuarios.Remove(usuario);
                DisplayAlert("Remover", $"Remover usuário com ID {usuario.Id}", "OK");
            }
        }
    }
}
