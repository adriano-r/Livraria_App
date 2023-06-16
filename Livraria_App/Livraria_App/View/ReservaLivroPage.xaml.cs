using Livraria_App.Model;
using Livraria_App.Services;
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

        private ReservaLivro reserva;
        private ReservaLivroApi api;
        private List<ReservaLivro> reservas;
        public ReservaLivroPage()
        {
            InitializeComponent();

            api = new ReservaLivroApi();
            reservas = new List<ReservaLivro>();
            LoadReservas();

            //carrinho = new ObservableCollection<ItemCarrinho>();
            //CarrinhoListView.ItemsSource = carrinho;
        }

        private async void LoadReservas()
        {
            try
            {
                reservas = await api.GetReservas();
                //ReservasListView.ItemsSource = reservas;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private void ReservarButtonClicked(object sender, EventArgs e)
        {
            int usuarioId;
            int livroId;

            if (int.TryParse(entUsrId.Text, out usuarioId) && int.TryParse(entLvrId.Text, out livroId))
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
            return true;
        }

        private void AdicionarAoCarrinho(int usuarioId, int livroId)
        {
            carrinho.Add(new ItemCarrinho { Id = livroId, Nome = $"Livro {livroId}", Quantidade = 1 });
        }

        private void RemoverButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var livroId = (int)button.CommandParameter;

            var item = carrinho.FirstOrDefault(i => i.Id == livroId);
            if (item != null)
            {
                carrinho.Remove(item);
            }
        }

        private void LimparCampos()
        {
            entUsrId.Text = string.Empty;
            entLvrId.Text = string.Empty;
        }

        private async void btLocalizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                reserva = await api.GetReserva(Convert.ToInt32(entId.Text));
                if (reserva.id > 0)
                {
                    entUsrId.Text = reserva.UsuarioId.ToString();
                    entLvrId.Text = reserva.LivroId.ToString();
                    entStatus.Text = reserva.Status;
                    DateTime dataReserva = reserva.DataReserva ?? DateTime.MinValue;
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
                reserva = await api.GetReserva(Convert.ToInt32(entId.Text));
                if (reserva.id > 0)
                {
                    await api.DeleteReserva(Convert.ToInt32(entId.Text));
                }
                await DisplayAlert("Alerta", "Reserva excluída com sucesso!", "Ok");

                LoadReservas();

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
                reserva = new ReservaLivro();
                reserva.UsuarioId = Convert.ToInt32(entUsrId.Text);
                reserva.LivroId = Convert.ToInt32(entLvrId.Text);
                reserva.Status = entStatus.Text;
                reserva.DataReserva = DateTime.Now.ToLocalTime();

                if (btSalvar.Text == "Atualizar")
                {
                    reserva.id = Convert.ToInt32(entId.Text);
                    await api.UpDateReserva(reserva);
                    await DisplayAlert("Alerta", "Reserva atualizada com sucesso!", "Ok");
                }
                else
                {
                    await api.CreateReserva(reserva);
                    await DisplayAlert("Alerta", "Reserva criada com sucesso!", "Ok");
                }

                LoadReservas();

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
            entUsrId.Text = string.Empty;
            entLvrId.Text = string.Empty;
            entStatus.Text = string.Empty;
        }
    }

    public class ItemCarrinho
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}