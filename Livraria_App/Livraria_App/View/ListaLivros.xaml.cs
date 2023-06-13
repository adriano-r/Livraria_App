using Livraria_App.Model;
using Livraria_App.Services;
using Livraria_App.ViewModel;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Livraria_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaLivros : ContentPage
    {
        private Livro livro;
        private LivrosApi api;
        private List<Livro> livros;

        public ListaLivros()
        {
            InitializeComponent();

            BindingContext = new LivrosViewModel();
            api = new LivrosApi();
            livros = new List<Livro>();

            LoadLivros();
        }

        private async void LoadLivros()
        {
            try
            {
                livros = await api.GetLivros();
                LivrosListView.ItemsSource = livros;
            }
            catch (Exception erro)
            {
                await DisplayAlert("Erro", erro.Message, "Ok");
            }
        }

        private void CriarLivro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LivroPage());
        }

        private void Reservar_Clicked(object sender, EventArgs e)
        {
            
        }
    }

}
