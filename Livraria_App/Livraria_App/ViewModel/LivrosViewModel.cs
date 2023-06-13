using Java.Util;
using Livraria_App.Model;
using Livraria_App.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Livraria_App.ViewModel
{
    public class LivrosViewModel : INotifyPropertyChanged
    {
        private List<Livro> _livros;

        public List<Livro> Livros
        {
            get { return _livros; }
            set
            {
                _livros = value;
                OnPropertyChanged();
            }
        }

        public LivrosViewModel()
        {
            LoadLivros();
        }

        private async void LoadLivros()
        {
            try
            {
                LivrosApi api = new LivrosApi();
                Livros = await api.GetLivros();
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
