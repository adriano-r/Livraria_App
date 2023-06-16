using Livraria_App.Model;
using Livraria_App.Services;
using Livraria_App.ViewModel;
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
    public partial class ListaReservaLivros : ContentPage
    {
        private ReservaLivro reserva;
        private ReservaLivroApi api;
        private List<ReservaLivro> reservas;
        public ListaReservaLivros()
        {
            InitializeComponent();

            BindingContext = new ReservaLivroViewModel();
            api = new ReservaLivroApi();
            reservas = new List<ReservaLivro>();

            LoadReservas();
        }

        private async void LoadReservas()
        {
            try
            {
                reservas = await api.GetReservas();
                ReservasListView.ItemsSource = reservas;
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "Ok");
            }
        }

        private void CriarReserva_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ReservaLivroPage());
        }
    }
}