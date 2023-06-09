using Livraria_App.Model;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Livraria_App.ViewModel
{
    public class ListaUsuariosViewModel : BaseViewModel
    {
        private ObservableCollection<Usuario> _usuarios;
        public ObservableCollection<Usuario> Usuarios
        {
            get { return _usuarios; }
            set { SetProperty(ref _usuarios, value); }
        }

        public Command CarregarUsuariosCommand { get; }

        public ListaUsuariosViewModel()
        {
            CarregarUsuariosCommand = new Command(async () => await CarregarUsuarios());
        }

        private async Task CarregarUsuarios()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "https://repo-pi-gold.vercel.app/api/usuarios";
                HttpResponseMessage response = await client.GetAsync(url);

                Console.Write(response.Content);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                    Usuarios = new ObservableCollection<Usuario>(usuarios);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Falha ao carregar usuários", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", $"Falha ao carregar usuários: {ex.Message}", "OK");
            }
        }

        public void EditarUsuario(Usuario usuario)
        {
            // Lógica para editar o usuário
        }

        public void RemoverUsuario(Usuario usuario)
        {
            // Lógica para remover o usuário
        }
    }
}
