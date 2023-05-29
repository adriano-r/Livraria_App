using Livraria_App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Android.Graphics.ImageDecoder;

namespace Livraria_App
{
    public partial class MainPage : ContentPage
    {
        public List<Livro> LivrosDestacados { get; set; }
        public List<Livro> OutrosLivros { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Preencha os dados dos livros destacados
            LivrosDestacados = new List<Livro>()
        {
            new Livro("Livro 1", "Autor 1", "Descrição do Livro Destacado 1", 10, "Book_CSharp.jpg"),
            new Livro("Livro 2", "Autor 2", "Descrição do Livro Destacado 1", 10, "Book_CSharp.jpg"),
            new Livro("Livro 3", "Autor 3", "Descrição do Livro Destacado 1", 10, "Book_CSharp.jpg")
        };

            // Preencha os dados dos outros livros
            OutrosLivros = new List<Livro>()
        {
            new Livro("Outro Livro", "Outro Autor", "Descrição do Outro Livro", 5, "Book_CSharp.jpg"),
            new Livro("Outro Livro", "Outro Autor", "Descrição do Outro Livro", 5, "Book_CSharp.jpg"),
            new Livro("Outro Livro", "Outro Autor", "Descrição do Outro Livro", 5, "Book_CSharp.jpg"),
            new Livro("Outro Livro", "Outro Autor", "Descrição do Outro Livro", 5, "Book_CSharp.jpg")
        };

            // Atribua a origem de dados aos carrosséis
            CarouselViewLivros.ItemsSource = LivrosDestacados;
            CarouselViewOutrosLivros.ItemsSource = OutrosLivros;
        }
    }

}