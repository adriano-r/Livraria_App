using Livraria_App.Model;
using Livraria_App.Services;
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
    public partial class LivroPage : ContentPage
    {
        private Livro livro;
        private LivrosApi api;
        public LivroPage()
        {
            InitializeComponent();
            api = new LivrosApi();
        }

        private async void btLocalizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                livro = await api.GetLivro(Convert.ToInt32(entId.Text));
                if (livro.id > 0)
                {
                    entTitulo.Text = livro.Titulo;
                    entAutor.Text = livro.Autor;
                    entDesc.Text = livro.Descricao;
                    entDisp.Text = livro.Quantidade.ToString();
                    entImg.Text = livro.Imagem.ToString();
                    btSalvar.Text = "Atualizar";
                }
                else btSalvar.Text = "Cadastrar";
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "Ok");
            }
        }

        private async void btExcluir_Clicked(object sender, EventArgs e)
        {
            try
            {
                livro = await api.GetLivro(Convert.ToInt32(entId.Text));
                if (livro.id > 0)
                {
                    await api.DeleteLivro(Convert.ToInt32(entId.Text));
                }
                await DisplayAlert("Alerta", "Livro excluido com sucesso!", "Ok");
                this.LimpaCampos();
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "Ok");
            }
        }

        private async void btSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                livro = new Livro();
                livro.Titulo = entTitulo.Text;
                livro.Autor = entAutor.Text;
                livro.Descricao = entDesc.Text;
                livro.Quantidade = Convert.ToInt32(entDisp.Text);
                livro.Imagem = entImg.Text;

                if(btSalvar.Text == "Atualizar")
                {
                    livro.id = Convert.ToInt32(entId.Text);
                    await api.UpDateLivro(livro);
                    await DisplayAlert("Alerta", "Livro Atualizado com sucesso!", "Ok");
                }
                else
                {
                    await api.CreateLivro(livro);
                    await DisplayAlert("Alerta", "Livro Criado com sucesso!", "Ok");
                }

                this.LimpaCampos();
            }
            catch (Exception error)
            {
                await DisplayAlert("Erro", error.Message, "Ok");
            }
        }

        private void LimpaCampos()
        {
            entId.Text = string.Empty;
            entTitulo.Text = string.Empty;
            entAutor.Text = string.Empty;
            entDesc.Text = string.Empty;
            entDisp.Text = string.Empty;
            entImg.Text = string.Empty;
        }
    }
}