using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Livraria_App.View.Submenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubmenuPageFlyout : ContentPage
    {
        public ListView ListView;

        public SubmenuPageFlyout()
        {
            InitializeComponent();

            BindingContext = new SubmenuPageFlyoutViewModel();
            ListView = MenuItemsListView;

        }
        private class SubmenuPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SubmenuPageFlyoutMenuItem> MenuItems { get; set; }

            public SubmenuPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<SubmenuPageFlyoutMenuItem>(new[]
                {

                    new SubmenuPageFlyoutMenuItem { Id = 0, Icon = "home.png" ,Title = "Home", TargetType=typeof(SubmenuPageDetail) },
                    new SubmenuPageFlyoutMenuItem { Id = 1, Icon = "categoria.png", Title = "Categorias", TargetType = typeof(HomePage) },
                    new SubmenuPageFlyoutMenuItem { Id = 2, Icon = "livro.png", Title = "Livros" , TargetType = typeof(LivroPage)},
                    new SubmenuPageFlyoutMenuItem { Id = 3, Icon = "user.png", Title = "Usuarios" , TargetType = typeof(ListaUsuarios)},
                    new SubmenuPageFlyoutMenuItem { Id = 4, Icon = "carrinho.png", Title = "Reservados" , TargetType = typeof(ReservaLivroPage)},
                    new SubmenuPageFlyoutMenuItem { Id = 5, Icon = "carrinho.png", Title = "Criar Livro" , TargetType = typeof(CriarLivro)},
                    new SubmenuPageFlyoutMenuItem { Id = 6, Icon = "",Title = "Logout" , TargetType = typeof(ListaUsuarios)},
                    new SubmenuPageFlyoutMenuItem { Id = 7, Icon = "",Title = "Login" , TargetType = typeof(LoginPage)},
                    new SubmenuPageFlyoutMenuItem { Id = 8, Icon = "",Title = "Registrar" , TargetType = typeof(RegisterPage)},

                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            SessionManager.Instance.IsUserLoggedIn = false;
            Navigation.PushAsync(new LoginPage());
        }
    }
}
