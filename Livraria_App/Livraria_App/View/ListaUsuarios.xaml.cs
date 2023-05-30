using System;
using System.Collections.Generic;
using System.Linq;
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

            Usuarios = new List<Usuario>()
            {
                new Usuario { Id = 1, Nome = "Usuário 1", Sobrenome = "Sobrenome 1", Email = "usuario1@example.com", Avatar = "user.png" },
                new Usuario { Id = 2, Nome = "Usuário 2", Sobrenome = "Sobrenome 2", Email = "usuario2@example.com", Avatar = "user.png" },
                new Usuario { Id = 3, Nome = "Usuário 3", Sobrenome = "Sobrenome 3", Email = "usuario3@example.com", Avatar = "user.png" }
            };

            UsuariosListView.ItemsSource = Usuarios;
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

    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}
