using Android.Views;
using Livraria_App.Model;
using Livraria_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Livraria_App.ViewModel
{
    public class UsuariosViewModel : INotifyPropertyChanged
    {
        private List<Usuario> _usuarios;
        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
            set
            {
                _usuarios = value;
                OnPropertyChanged();
            }
        }

        public UsuariosViewModel()
        {
            LoadUsuarios();
        }

        private async void LoadUsuarios()
        {
            try
            {
                UsuariosApi api = new UsuariosApi();
                Usuarios = await api.GetUsuarios();
                Console.WriteLine(Usuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na requisição: " + ex.Message);
            }
        }

        // Implemente a interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
