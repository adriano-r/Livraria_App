using Livraria_App.Model;
using Livraria_App.Services;
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
    public partial class RegisterPage : ContentPage
    {
        private Usuario usuario;
        private UsuariosApi api;
        private List<Usuario> usuarios;
        public RegisterPage()
        {
            InitializeComponent();
            api = new UsuariosApi();
            usuarios = new List<Usuario>();
            LoadUsuarios();
        }

        private async void LoadUsuarios()
        {
            try
            {
                usuarios = await api.GetUsuarios();
            }
            catch (Exception ex)
            {
               await DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private async void Registrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuario();
                usuario.Nome = entNome.Text;
                usuario.Sobrenome = entSobre.Text;
                usuario.Email = entEmail.Text;
                usuario.Senha = entSenha.Text;
                usuario.Avatar = string.Empty;

                    await api.CreateUsuario(usuario);
                    await DisplayAlert("Alerta", "Usuário criado com sucesso!", "Ok");

                LoadUsuarios();

                this.LimpaCampos();
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "Ok");
            }
        }

        private void LimpaCampos()
        {
            entNome.Text = string.Empty;
            entSobre.Text = string.Empty;
            entEmail.Text = string.Empty;
            entSenha.Text = string.Empty;
            //entAvt.Text = string.Empty;
        }
    }
}
