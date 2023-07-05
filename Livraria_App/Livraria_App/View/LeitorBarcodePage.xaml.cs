using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Livraria_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeitorBarcodePage : ContentPage
    {
        public LeitorBarcodePage()
        {
            InitializeComponent();

            // Obtém as dimensões da tela do dispositivo
            var screenWidth = DeviceDisplay.MainDisplayInfo.Width;
            var screenHeight = DeviceDisplay.MainDisplayInfo.Height;

            // Define a posição e o tamanho do BoxView
            var leitorQRCodeWidth = screenWidth * 0.8;  // 80% da largura da tela
            var leitorQRCodeHeight = screenHeight * 0.5;  // 50% da altura da tela
            var leitorQRCodeX = (screenWidth - leitorQRCodeWidth) / 2;  // Centraliza horizontalmente
            var leitorQRCodeY = (screenHeight - leitorQRCodeHeight) / 2;  // Centraliza verticalmente
            AbsoluteLayout.SetLayoutBounds(LeitorQRCodeBoxView, new Rectangle(leitorQRCodeX, leitorQRCodeY, leitorQRCodeWidth, leitorQRCodeHeight));
        }
    }
}