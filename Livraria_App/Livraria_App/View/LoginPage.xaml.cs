using Livraria_App.API;
using Livraria_App.Model;
using Plugin.Connectivity;
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
    public partial class LoginPage : ContentPage
    {
        List<User> listaUsuarios;
        public LoginPage()
        {
            InitializeComponent();
            listaUsuarios = new List<User>();
        }

        public async void Logar()
        {

            //listaUsuarios = await ApiService.ObterUser();

            //var usuario = listaUsuarios.Where(x => x.Nome.ToLower() == txtNome.Text.ToLower() && x.Senha.ToLower() == txtSenha.Text.ToLower()).ToList();
            if (txtNome.Text == "admin" && txtSenha.Text == "123456")
            {

                await Navigation.PushAsync(new ListaUsuarios());
            }
            else
            {
                DisplayAlert("Acesso negado!", "Usuario ou Senha incorreta!", "Ok");
            }
        }
    }

    public void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegisterPage());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Logar();
    }
}
}