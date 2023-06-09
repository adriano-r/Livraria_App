using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Livraria_App.ViewModel;

namespace Livraria_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaUsuarios : ContentPage
    {
        public ListaUsuarios()
        {
            InitializeComponent();
            BindingContext = new ListaUsuariosViewModel();
        }
    }
}
