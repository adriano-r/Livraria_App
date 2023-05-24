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
                new Livro { Titulo = "Livro  1", Descricao = "Descrição do Livro Destacado 1", Imagem = "Book1.png" },
                new Livro { Titulo = "Livro  2", Descricao = "Descrição do Livro Destacado 2", Imagem = "Book2.png" },
                new Livro { Titulo = "Livro  3", Descricao = "Descrição do Livro Destacado 3", Imagem = "Book3.png" }
            };

            // Preencha os dados dos outros livros
            OutrosLivros = new List<Livro>()
            {
                new Livro { Titulo = "Outro Livro 1", Descricao = "Descrição do Outro Livro 1", Imagem = "Book4.png" },
                new Livro { Titulo = "Outro Livro 2", Descricao = "Descrição do Outro Livro 2", Imagem = "Book5.png" },
                new Livro { Titulo = "Outro Livro 3", Descricao = "Descrição do Outro Livro 3", Imagem = "Book6.png" },
                new Livro { Titulo = "Outro Livro 4s", Descricao = "Descrição do Outro Livro 4", Imagem = "Book7.png" }
            };

            // Atribua a origem de dados aos carrosséis
            CarouselViewLivros.ItemsSource = LivrosDestacados;
            CarouselViewOutrosLivros.ItemsSource = OutrosLivros;
        }

        public class Livro
        {
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public string Imagem { get; set; }
        }
    }
}