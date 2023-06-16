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
    public partial class UsuarioPage : ContentPage
    {
        private Usuario usuario;
        private UsuariosApi api;
        private List<Usuario> usuarios;

        public UsuarioPage()
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
                // Obter a lista de usuários da API
                usuarios = await api.GetUsuarios();

                // Definir a origem de dados para o ListView
                //UsuariosListView.ItemsSource = usuarios;
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "Ok");
            }
        }

        private async void btLocalizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                usuario = await api.GetUsuario(Convert.ToInt32(entId.Text));
                if (usuario.id > 0)
                {
                    entNome.Text = usuario.Nome;
                    entSobre.Text = usuario.Sobrenome;
                    entEmail.Text = usuario.Email.ToString();
                    entAvt.Text = usuario.Avatar.ToString();
                    btSalvar.Text = "Atualizar";
                }
                else btSalvar.Text = "Cadastrar";
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "Ok");
            }
        }

        private async void btExcluir_Clicked(object sender, EventArgs e)
        {
            try
            {
                usuario = await api.GetUsuario(Convert.ToInt32(entId.Text));
                if (usuario.id > 0)
                {
                    await api.DeleteUsuario(Convert.ToInt32(entId.Text));
                }
                await DisplayAlert("Alerta", "Usuário excluído com sucesso!", "Ok");

                LoadUsuarios(); // Atualizar a lista de usuários

                this.LimpaCampos();
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "Ok");
            }
        }

        private async void btSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuario();
                usuario.Nome = entNome.Text;
                usuario.Sobrenome = entSobre.Text;
                usuario.Email = entEmail.Text;
                usuario.Avatar = entAvt.Text;

                if (btSalvar.Text == "Atualizar")
                {
                    usuario.id = Convert.ToInt32(entId.Text);
                    await api.UpDateUsuario(usuario);
                    await DisplayAlert("Alerta", "Usuário atualizado com sucesso!", "Ok");
                }
                else
                {
                    await api.CreateUsuario(usuario);
                    await DisplayAlert("Alerta", "Usuário criado com sucesso!", "Ok");
                }

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
            entId.Text = string.Empty;
            entNome.Text = string.Empty;
            entSobre.Text = string.Empty;
            entEmail.Text = string.Empty;
            entAvt.Text = string.Empty;
        }
    }
}
