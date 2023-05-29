using Livraria_App.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Livraria_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaLivros : ContentPage
    {
        public ObservableCollection<Livro> Livros { get; set; }

        public ListaLivros()
        {
            InitializeComponent();

            Livros = new ObservableCollection<Livro>
    {
        new Livro("Livro 1", "Autor 1", "Descrição do Livro 1", 5, "Book_Xamarin.png") { Id = 1 },
        new Livro("Livro 2", "Autor 2", "Descrição do Livro 2", 3, "Book_Xamarin.png") { Id = 2 },
        new Livro("Livro 3", "Autor 3", "Descrição do Livro 3", 2, "Book_Xamarin.png") { Id = 3 },
        new Livro("Livro 4", "Autor 4", "Descrição do Livro 4", 7, "Book_Xamarin.png") { Id = 4 },
        new Livro("Livro 5", "Autor 5", "Descrição do Livro 5", 1, "Book_Xamarin.png") { Id = 5 }
    };

            MyListView.ItemsSource = Livros;
        }


        async void VerDetalhesButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var id = (int)button.CommandParameter;
            var livro = Livros.FirstOrDefault(l => l.Id == id);

            if (livro != null)
            {
                await DisplayAlert("Detalhes do Livro", $"Título: {livro.Titulo}\nAutor: {livro.Autor}\nDescrição: {livro.Descricao}\nQuantidade: {livro.Quantidade}", "OK");
            }
        }

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}
