using Android.Content.Res;
using Livraria_App.Model;
using Livraria_App.Services;
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
        UsuariosApi api = new UsuariosApi();
        public LoginPage()
        {
            InitializeComponent();
            listaUsuarios = new List<Usuario>();
        }

        public async void Logar()
        {
            listaUsuarios = await api.GetUsuarios();

            var usuario = listaUsuarios.FirstOrDefault(x => x.Nome.ToLower() == entNome.Text.ToLower() && x.Senha.ToLower() == entSenha.Text.ToLower());
            if (usuario != null)
            {
                SessionManager.Instance.IsUserLoggedIn = true;
                SessionManager.Instance.NivelAcesso = usuario.NivelAcesso;
                SessionManager.Instance.id = usuario.id.ToString();

                if (usuario.NivelAcesso == "admin")
                {
                    await Navigation.PushAsync(new SubmenuPage());
                }
                else
                {
                    await Navigation.PushAsync(new SubmenuPageDetail());
                }
            }
            else
            {
                await DisplayAlert("Ops...!", "Usuário ou Senha incorreta!", "Tente Novamente");
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