using GoogleVisionBarCodeScanner;
using Livraria_App.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace Livraria_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {

        public ScanPage()
        {
            InitializeComponent();
            GoogleVisionBarCodeScanner.Methods.AskForRequiredPermission();

            // Cria o campo estéril
            var sterileField = new BoxView
            {
                BackgroundColor = Color.Transparent,
                Opacity = 0.5 // Define a opacidade para torná-lo semi-transparente
            };

            // Cria o campo de leitura
            var scanField = new BoxView
            {
                BackgroundColor = Color.Transparent // Define a cor como transparente para que o scanner possa ser exibido
            };

            // Cria o componente GoogleVisionScannerView
            var googleVisionScannerView = new GoogleVisionScannerView
            {
                IsScanning = true,
                // Defina outras propriedades do scanner conforme necessário
            };

            // Manipula o evento OnScanResult para obter o resultado da leitura do código de barras
            googleVisionScannerView.OnScanResult += (result) =>
            {
                // Processa o resultado da leitura do código de barras
                // Aqui você pode adicionar sua lógica para manipular os dados do código de barras lido
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Barcode Scanned", result.ToString(), "OK");
                });
            };

            // Cria a estrutura de layout
            var layout = new AbsoluteLayout();
            layout.Children.Add(sterileField, new Rectangle(2, 0, 1, 1), AbsoluteLayoutFlags.All);
            layout.Children.Add(scanField, new Rectangle(0.2, 0.2, 0.6, 0.6), AbsoluteLayoutFlags.All);
            layout.Children.Add(googleVisionScannerView, new Rectangle(0.2, 0.2, 0.6, 0.6), AbsoluteLayoutFlags.All);

            // Define o layout como conteúdo da página
            Content = layout;

            // Obter informações sobre a exibição principal
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Orientação (Landscape, Portrait, Square, Unknown)
            var orientation = mainDisplayInfo.Orientation;

            // Rotação (0, 90, 180, 270)
            var rotation = mainDisplayInfo.Rotation;

            // Largura (em pixels)
            var width = mainDisplayInfo.Width;

            // Altura (em pixels)
            var height = mainDisplayInfo.Height;

            // Densidade de tela
            var density = mainDisplayInfo.Density;
        }






        private void Camera_OnDetected(object sender, GoogleVisionBarCodeScanner.OnDetectedEventArg e)
        {
            List<BarcodeResult> obj = e.BarcodeResults;

            string result = string.Empty;
            for (int i = 0; i < obj.Count; i++)
            {
                result += $"Type : {obj[i].BarcodeType}, Value : {obj[i].DisplayValue}{Environment.NewLine}";
            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Result", result, "OK");
                Camera.IsScanning = true;
            });
        }

        private void ZoomIn_Clicked(object sender, EventArgs e)
        {
            ZoomCamera(1.2f);
        }

        private void ZoomOut_Clicked(object sender, EventArgs e)
        { 

              ZoomCamera(0.8f);
            
        }
        private void ZoomCamera(float zoom)
        {
           
            
                Camera.Scale *= zoom;
            //  DisplayAlert("zoom:", Camera.Scale.ToString(), "ok");


        }

        private async Task LerQRCode_ClickedAsync(object sender, EventArgs e)
        {
            var scan = new ZXing.Net.Mobile.Forms.ZXingScannerPage();
            await Navigation.PushModalAsync(scan);

            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    await DisplayAlert("Valor: ", "" + result.Text, "OK");
                });
            };
            Camera.IsVisible = !Camera.IsVisible;
        }

        private void Lanterna_Clicked(object sender, EventArgs e)
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Orientation (Landscape, Portrait, Square, Unknown)
            var orientation = mainDisplayInfo.Orientation;

            // Rotation (0, 90, 180, 270)
            var rotation = mainDisplayInfo.Rotation;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;

            // Screen density
            var density = mainDisplayInfo.Density;

            DisplayAlert("DisplayInfo",  mainDisplayInfo.ToString() + orientation + rotation + width + height + density, "ok");
            
            Camera.TorchOn = !Camera.TorchOn;
        }

        private async void LerQRCode_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXing.Net.Mobile.Forms.ZXingScannerPage();
            await Navigation.PushModalAsync(scan);

            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    await DisplayAlert("Valor: ", "" + result.Text, "OK");
                });
            };
        }
    }
}

