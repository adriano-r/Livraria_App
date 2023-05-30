using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Livraria_App.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservaLivroPage : ContentPage
    {
        private ObservableCollection<ItemCarrinho> carrinho;

        public ReservaLivroPage()
        {
            InitializeComponent();

            carrinho = new ObservableCollection<ItemCarrinho>();
            CarrinhoListView.ItemsSource = carrinho;
        }

        private void ReservarButtonClicked(object sender, EventArgs e)
        {
            int usuarioId;
            int livroId;

            if (int.TryParse(UsuarioEntry.Text, out usuarioId) && int.TryParse(LivroEntry.Text, out livroId))
            {
                if (VerificarDisponibilidadeLivro(livroId))
                {
                    AdicionarAoCarrinho(usuarioId, livroId);
                    DisplayAlert("Sucesso", "Livro adicionado ao carrinho!", "OK");
                    LimparCampos();
                }
                else
                {
                    DisplayAlert("Erro", "O livro selecionado não está disponível para reserva.", "OK");
                }
            }
            else
            {
                DisplayAlert("Erro", "Por favor, insira IDs válidos para o usuário e o livro.", "OK");
            }
        }

        private bool VerificarDisponibilidadeLivro(int livroId)
        {
            // Implemente a lógica para verificar a disponibilidade do livro
            // Retorne true se o livro estiver disponível para reserva, caso contrário, retorne false

            // Exemplo de lógica fictícia para verificar disponibilidade
            // Aqui estamos apenas retornando true para todos os livros
            return true;
        }

        private void AdicionarAoCarrinho(int usuarioId, int livroId)
        {
            // Implemente a lógica para adicionar o livro ao carrinho
            // Registre as informações do livro no carrinho
            // Aqui você pode adicionar o livro a uma lista de carrinho ou qualquer outro mecanismo de armazenamento

            // Exemplo de adição fictícia ao carrinho
            carrinho.Add(new ItemCarrinho { Id = livroId, Nome = $"Livro {livroId}", Quantidade = 1 });
        }

        private void RemoverButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var livroId = (int)button.CommandParameter;

            // Implemente a lógica para remover o livro do carrinho
            // Aqui você pode remover o livro da lista de carrinh+o ou qualquer outro mecanismo de armazenamento

            // Exemplo de remoção fictícia do carrinho
            var item = carrinho.FirstOrDefault(i => i.Id == livroId);
            if (item != null)
            {
                carrinho.Remove(item);
            }
        }

        private void LimparCampos()
        {
            UsuarioEntry.Text = string.Empty;
            LivroEntry.Text = string.Empty;
        }
    }

    public class ItemCarrinho
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}