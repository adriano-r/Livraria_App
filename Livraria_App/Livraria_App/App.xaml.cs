using Livraria_App.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Livraria_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

#if DEBUG
            HotReloader.Current.Run(this);
#endif

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new LoginPage());
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
