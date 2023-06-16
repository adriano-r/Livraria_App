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

        private ReservaLivro reserva;
        private ReservaLivroApi apiReserva;

        private List<ReservaLivro> _reservas;
        public List<ReservaLivro> Reservas
        {
            get { return _reservas; }
            set
            {
                _reservas = value;
                OnPropertyChanged();
            }
        }


        public ListaLivros()
        {
            InitializeComponent();

            BindingContext = new LivrosViewModel();
            api = new LivrosApi();
            livros = new List<Livro>();

            ReservaLivroApi apiReserva = new ReservaLivroApi();
            List<ReservaLivro> reservas = new List<ReservaLivro>();

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

        private async void Reservar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new ReservaLivroPage());
                //reserva = new ReservaLivro();
                //reserva.UsuarioId = Convert.ToInt32(10);
                //reserva.LivroId = Convert.ToInt32(10);
                //reserva.Status = "Reservado";
                //reserva.DataReserva = DateTime.Now.ToLocalTime();

                //    reserva.id = Convert.ToInt32(10);
                //    await apiReserva.CreateReserva(reserva);
                //    await DisplayAlert("Alerta", "Reserva criada com sucesso!", "Ok");

            }
            catch(Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }

        }
    
    }
}
