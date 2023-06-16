using Livraria_App.Model;
using Livraria_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Livraria_App.ViewModel
{
    public class ReservaLivroViewModel
    {
        private List<ReservaLivro> _reservas;
        public List<ReservaLivro> Reservas
        {
            get { return _reservas; }
            set
            {
                _reservas= value;
                OnPropertyChanged();
            }
        }

        public ReservaLivroViewModel()
        {
            LoadReservas();
        }

        private async void LoadReservas()
        {
            try
            {
                ReservaLivroApi api = new ReservaLivroApi();
                Reservas = await api.GetReservas();
                //Console.WriteLine(Usuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na requisição: " + ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
