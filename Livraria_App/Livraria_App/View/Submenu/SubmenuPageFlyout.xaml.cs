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
                    new SubmenuPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new SubmenuPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new SubmenuPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new SubmenuPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new SubmenuPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
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