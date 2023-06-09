using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Livraria_App.Model;
//using Livraria_App.Services;
using MvvmHelpers;

namespace Livraria_App.ViewModel
{
    public class ListaLivrosViewModel : BaseViewModel
    {
        private ObservableCollection<Livro> _livros;
        public ObservableCollection<Livro> Livros
        {
            get { return _livros; }
            set { SetProperty(ref _livros, value); }
        }

        //private readonly LivroService _livroService;

        public ListaLivrosViewModel()
        {
          //  _livroService = new LivroService();
            Livros = new ObservableCollection<Livro>();
        }

        public async Task LoadLivros()
        {
            // Obter livros do serviço
            //List<Livro> listaLivros = await _livroService.GetLivros();

            // Atualizar a propriedade Livros com a lista retornada
            //Livros = new ObservableCollection<Livro>(listaLivros);
        }

        public async Task RemoverLivro(Livro livro)
        {
            // Remover o livro da lista
            Livros.Remove(livro);

            // Chamar o serviço para remover o livro
            //await _livroService.RemoverLivro(livro);
        }
    }
}
