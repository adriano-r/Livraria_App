using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Livraria_App.ViewModel;
using Livraria_App.Model;
using Livraria_App.Services;
using System.Collections.Generic;
using System;

namespace Livraria_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaUsuarios : ContentPage
    {

        private Usuario usuario;
        private UsuariosApi api;
        private List<Usuario> usuarios;
        public ListaUsuarios()
        {
            InitializeComponent();

            BindingContext = new UsuariosViewModel();
            api = new UsuariosApi();
            usuarios = new List<Usuario>();

            LoadUsuarios();
        }

        private async void LoadUsuarios()
        {
            try
            {
                usuarios = await api.GetUsuarios();
                UsuariosListView.ItemsSource = usuarios;
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "Ok");
            }
        }

        private void CriarUsuario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UsuarioPage());
        }
    }

}
