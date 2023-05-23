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

namespace Livraria_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubmenuFlyout : ContentPage
    {
        public ListView ListView;

        public SubmenuFlyout()
        {
            InitializeComponent();

            BindingContext = new SubmenuFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class SubmenuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SubmenuFlyoutMenuItem> MenuItems { get; set; }

            public SubmenuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<SubmenuFlyoutMenuItem>(new[]
                {
                    new SubmenuFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new SubmenuFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new SubmenuFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new SubmenuFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new SubmenuFlyoutMenuItem { Id = 4, Title = "Page 5" },
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
    }
}