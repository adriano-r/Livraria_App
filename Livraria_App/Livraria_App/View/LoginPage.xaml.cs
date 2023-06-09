using Android.Content.Res;
using Livraria_App.API;
using Livraria_App.Model;
using Livraria_App.View.Submenu;
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
        List<Usuario> listaUsuarios;
        public LoginPage()
        {
            InitializeComponent();
            listaUsuarios = new List<Usuario>();
        }

        public void Logar()
        {

            //listaUsuarios = await ApiService.ObterUser();

            //var usuario = listaUsuarios.Where(x => x.Nome.ToLower() == txtNome.Text.ToLower() && x.Senha.ToLower() == txtSenha.Text.ToLower()).ToList();
            if (txtEmail.Text == "adriano" && txtSenha.Text == "123456")
            {

                Navigation.PushAsync(new SubmenuPage());
            }
            else
            {
                DisplayAlert("Ops...!", "Usuario ou Senha incorreta!", "Tente Novamente");
            }
        }

        public void Registrar() 
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Registrar();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            Logar();
        }
    }
}