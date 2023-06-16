﻿using Android.Content.Res;
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

            var usuario = listaUsuarios.Where(x => x.Nome.ToLower() == entNome.Text.ToLower() && x.Senha.ToLower() == entSenha.Text.ToLower()).ToList();
            if (usuario.Count > 0)
            {
                SessionManager.Instance.IsUserLoggedIn = true;
                SessionManager.Instance.Usuario.Nome = entNome.Text ;
                await Navigation.PushAsync(new SubmenuPage());
            }
            else
            {
                await DisplayAlert("Ops...!", "Usuario ou Senha incorreta!", "Tente Novamente");
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