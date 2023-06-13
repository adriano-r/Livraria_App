using Livraria_App.Model;
using Livraria_App.Services;
using Livraria_App.View.Submenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Telephony.CarrierConfigManager;

namespace Livraria_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaLivros : ContentPage
    {
        private UsuariosApi api;

        public List<Livro> Livros { get; set; }

        public  ListaLivros()
        {
            InitializeComponent();
        
            api = new UsuariosApi();
            Livros = new List<Livro>();
            {
                new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", "Uma jornada épica na Terra Média", 3, "");
            };

            LivrosListView.ItemsSource = Livros;
        }

        private void Reservar_Clicked(object sender, EventArgs e)
        {

        }
    }

}
