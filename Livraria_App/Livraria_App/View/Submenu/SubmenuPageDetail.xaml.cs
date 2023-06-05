using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Livraria_App.Model;

namespace Livraria_App.View.Submenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubmenuPageDetail : ContentPage
    {
        public SubmenuPageDetail()
        {
            InitializeComponent();
        }

        private void ReserveButton_Clicked(object sender, EventArgs e)
        {
            Livro livro = new Livro("Harry Potter", "J.K. Rowling", "Uma emocionante história de bruxos e magia", 5, "https://m.media-amazon.com/images/I/61jgm6ooXzL._AC_UF1000,1000_QL80_.jpg");
            DisplayAlert("Reserva", $"Livro '{livro.Titulo}' reservado com sucesso!", "OK");
        }
    }
}
