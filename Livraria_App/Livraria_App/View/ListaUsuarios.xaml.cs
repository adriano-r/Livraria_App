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

        private void LoadUsuarios()
        {
            var usuarios = new List<Usuario>
        {
            new Usuario { Id = 0, Nome = "Don", Sobrenome = "Vito Corleone", Email = "coleone@gm.com", Avatar = "https://fms.wustl.edu/files/fms/Events/godfather.png" },
            new Usuario { Id = 1, Nome = "Al", Sobrenome = "Capone", Email = "al@gm.com", Avatar = "" },
            new Usuario { Id = 2, Nome = "Hyman", Sobrenome = "Roth", Email = "rh@gm.com", Avatar = "" }
        };

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Nome}, Sobrenome: {usuario.Sobrenome}, Email: {usuario.Email}, Avatar: {usuario.Avatar}");
            }

            UsuariosListView.ItemsSource = usuarios;
        }
    }


    //private void EditarButtonClicked(object sender, EventArgs e)
    //    {
    //        var button = (Button)sender;
    //        var id = (int)button.CommandParameter;
    //        var usuario = Usuarios.FirstOrDefault(u => u.Id == id);

    //        if (usuario != null)
    //        {
    //            DisplayAlert("Editar", $"Editar usuário com ID {usuario.Id}", "OK");
    //        }
    //    }

    //    private void RemoverButtonClicked(object sender, EventArgs e)
    //    {
    //        var button = (Button)sender;
    //        var id = (int)button.CommandParameter;
    //        var usuario = Usuarios.FirstOrDefault(u => u.Id == id);

    //        if (usuario != null)
    //        {
    //            Usuarios.Remove(usuario);
    //            DisplayAlert("Remover", $"Remover usuário com ID {usuario.Id}", "OK");
    //        }
    //    }
    
}
