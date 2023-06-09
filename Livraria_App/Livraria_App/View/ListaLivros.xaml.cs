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
                new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", "Uma jornada épica na Terra Média", 3, "https://5934488p.ha.azioncdn.net/capas-livros/9788533613409-j-r-r-tolkien-o-senhor-dos-aneis-1095107875.jpg"),
                new Livro("Cem Anos de Solidão", "Gabriel García Márquez", "A história da família Buendía ao longo de várias gerações", 2, "https://m.media-amazon.com/images/I/61jgm6ooXzL.jpg"),
                new Livro("1984", "George Orwell", "Um clássico distópico que retrata um futuro totalitário", 4, "https://m.media-amazon.com/images/I/71kxa1-0mfL._AC_UF1000,1000_QL80_.jpg"),
                                new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", "Uma jornada épica na Terra Média", 3, "https://5934488p.ha.azioncdn.net/capas-livros/9788533613409-j-r-r-tolkien-o-senhor-dos-aneis-1095107875.jpg"),
                new Livro("Cem Anos de Solidão", "Gabriel García Márquez", "A história da família Buendía ao longo de várias gerações", 2, "https://m.media-amazon.com/images/I/61jgm6ooXzL.jpg"),
                new Livro("1984", "George Orwell", "Um clássico distópico que retrata um futuro totalitário", 4, "https://m.media-amazon.com/images/I/71kxa1-0mfL._AC_UF1000,1000_QL80_.jpg"),
                                new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", "Uma jornada épica na Terra Média", 3, "https://5934488p.ha.azioncdn.net/capas-livros/9788533613409-j-r-r-tolkien-o-senhor-dos-aneis-1095107875.jpg"),
                new Livro("Cem Anos de Solidão", "Gabriel García Márquez", "A história da família Buendía ao longo de várias gerações", 2, "https://m.media-amazon.com/images/I/61jgm6ooXzL.jpg"),
                new Livro("1984", "George Orwell", "Um clássico distópico que retrata um futuro totalitário", 4, "https://m.media-amazon.com/images/I/71kxa1-0mfL._AC_UF1000,1000_QL80_.jpg"),
                                new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", "Uma jornada épica na Terra Média", 3, "https://5934488p.ha.azioncdn.net/capas-livros/9788533613409-j-r-r-tolkien-o-senhor-dos-aneis-1095107875.jpg"),
                new Livro("Cem Anos de Solidão", "Gabriel García Márquez", "A história da família Buendía ao longo de várias gerações", 2, "https://m.media-amazon.com/images/I/61jgm6ooXzL.jpg"),
                new Livro("1984", "George Orwell", "Um clássico distópico que retrata um futuro totalitário", 4, "https://m.media-amazon.com/images/I/71kxa1-0mfL._AC_UF1000,1000_QL80_.jpg"),
                                new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", "Uma jornada épica na Terra Média", 3, "https://5934488p.ha.azioncdn.net/capas-livros/9788533613409-j-r-r-tolkien-o-senhor-dos-aneis-1095107875.jpg"),
                new Livro("Cem Anos de Solidão", "Gabriel García Márquez", "A história da família Buendía ao longo de várias gerações", 2, "https://m.media-amazon.com/images/I/61jgm6ooXzL.jpg"),
                new Livro("1984", "George Orwell", "Um clássico distópico que retrata um futuro totalitário", 4, "https://m.media-amazon.com/images/I/71kxa1-0mfL._AC_UF1000,1000_QL80_.jpg"),
                                new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", "Uma jornada épica na Terra Média", 3, "https://5934488p.ha.azioncdn.net/capas-livros/9788533613409-j-r-r-tolkien-o-senhor-dos-aneis-1095107875.jpg"),
                new Livro("Cem Anos de Solidão", "Gabriel García Márquez", "A história da família Buendía ao longo de várias gerações", 2, "https://m.media-amazon.com/images/I/61jgm6ooXzL.jpg"),
                new Livro("teste", "teste", "test", 4, "https://m.media-amazon.com/images/I/71kxa1-0mfL._AC_UF1000,1000_QL80_.jpg")
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
                string message = $"Livro reservado:\n\n" +
                                 $"ID: {livro.Id}\n" +
                                 $"Título: {livro.Titulo}\n" +
                                 $"Autor: {livro.Autor}\n" +
                                 $"Descrição: {livro.Descricao}\n" +
                                 $"Quantidade: {livro.Quantidade}\n";

                DisplayAlert("Reservado!", message, "OK");
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
