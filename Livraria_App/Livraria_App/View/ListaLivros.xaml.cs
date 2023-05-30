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
                new Livro { Id = 1, Titulo = "Livro 1", Autor = "Autor 1", Descricao = "Descrição 1", Quantidade = 5, Imagem = "Book_Xamarin.png" },
                new Livro { Id = 2, Titulo = "Livro 2", Autor = "Autor 2", Descricao = "Descrição 2", Quantidade = 3, Imagem = "Book_Xamarin.png" },
                new Livro { Id = 3, Titulo = "Livro 3", Autor = "Autor 3", Descricao = "Descrição 3", Quantidade = 7, Imagem = "Book_Xamarin.png" }
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

    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }
    }
}
