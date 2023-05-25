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
            var livro = new Livro("Título do Livro", "Autor do Livro", "Descrição do Livro", 10);
            DisplayAlert("Reserva", $"Livro '{livro.Titulo}' reservado com sucesso!", "OK");
        }
    }
}
