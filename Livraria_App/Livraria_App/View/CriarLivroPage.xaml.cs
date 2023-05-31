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
    public partial class CriarLivroPage : ContentPage
    {
        private Entry tituloEntry;
        private Entry autorEntry;
        private Entry descricaoEntry;
        private Entry quantidadeEntry;
        private Entry imagemEntry;
        private Button criarLivroButton;

        public CriarLivroPage()
        {
            tituloEntry = new Entry
            {
                Placeholder = "Título do livro"
            };

            autorEntry = new Entry
            {
                Placeholder = "Autor do livro"
            };

            descricaoEntry = new Entry
            {
                Placeholder = "Descrição do livro"
            };

            quantidadeEntry = new Entry
            {
                Placeholder = "Quantidade do livro",
                Keyboard = Keyboard.Numeric
            };

            imagemEntry = new Entry
            {
                Placeholder = "URL da imagem do livro"
            };

            criarLivroButton = new Button
            {
                Text = "Criar Livro"
            };
            criarLivroButton.Clicked += CriarLivroButton_Clicked;

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    tituloEntry,
                    autorEntry,
                    descricaoEntry,
                    quantidadeEntry,
                    imagemEntry,
                    criarLivroButton
                }
            };
        }

        private void CriarLivroButton_Clicked(object sender, EventArgs e)
        {
            string titulo = tituloEntry.Text;
            string autor = autorEntry.Text;
            string descricao = descricaoEntry.Text;
            int quantidade = Convert.ToInt32(quantidadeEntry.Text);
            string imagem = imagemEntry.Text;

            Livro novoLivro = new Livro(titulo, autor, descricao, quantidade, imagem);

            // Aqui você pode fazer o que quiser com o novo livro (por exemplo, salvá-lo em uma lista)

            DisplayAlert("Sucesso", "Livro criado com sucesso!", "OK");

            // Limpar os campos após criar o livro
            LimparCampos();
        }

        private void LimparCampos()
        {
            tituloEntry.Text = string.Empty;
            autorEntry.Text = string.Empty;
            descricaoEntry.Text = string.Empty;
            quantidadeEntry.Text = string.Empty;
            imagemEntry.Text = string.Empty;
        }
    }
}