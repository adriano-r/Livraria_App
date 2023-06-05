using Livraria_App.Model;
using Livraria_App.View.Submenu;
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
    public partial class ListaLivros : ContentPage
    {
        public List<Livro> Livros { get; set; }

        public ListaLivros()
        {
            InitializeComponent();

            Livros = new List<Livro>()
            {
                new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", "Uma jornada épica na Terra Média", 3, "Book_Xamarin.png"),
                new Livro("Cem Anos de Solidão", "Gabriel García Márquez", "A história da família Buendía ao longo de várias gerações", 2, "Book_Xamarin.png"),
                new Livro("1984", "George Orwell", "Um clássico distópico que retrata um futuro totalitário", 4, "Book_Xamarin.png")
            };

            LivrosListView.ItemsSource = Livros;
        }

        private void EditarButtonClicked(object sender, EventArgs e)
        {
            
            var button = (Button)sender;
            var id = (int)button.CommandParameter;
            var livro = Livros.FirstOrDefault(l => l.Id == id);

            if (livro != null)
            {
                DisplayAlert("Editar", $"Editar livro com ID {livro.Id}", "OK");
            }
        }

        private void RemoverButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var id = (int)button.CommandParameter;
            var livro = Livros.FirstOrDefault(l => l.Id == id);

            if (livro != null)
            {
                Livros.Remove(livro);
                DisplayAlert("Remover", $"Remover livro com ID {livro.Id}", "OK");
            }
        }
    }

}
