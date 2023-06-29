using GoogleVisionBarCodeScanner;
using Livraria_App.View;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace Livraria_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            //GoogleVisionBarCodeScanner.Methods.SetSupportBarcodeFormat(GoogleVisionBarCodeScanner.BarcodeFormats.QRCode | GoogleVisionBarCodeScanner.BarcodeFormats.Code39);
            InitializeComponent();
            GoogleVisionBarCodeScanner.Methods.AskForRequiredPermission();
        }

        //private void ZXingScannerView_OnScanResult(ZXing.Result result)
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        scanResultText.Text = result.Text + " (type: " + result.BarcodeFormat.ToString() + ")";
        //    });
        //}


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

        private void LerQRCode_Clicked(object sender, EventArgs e)
        {
            //var scan = new ZXingScannerPage();
            //await Navigation.PushModalAsync(scan);

            //scan.OnScanResult += (result) =>
            //{
            //    Device.BeginInvokeOnMainThread(async () =>
            //    {
            //        await Navigation.PopModalAsync();
            //        await DisplayAlert("Valor: ", "" + result.Text, "OK");
            //    });
            //};
            Camera.IsVisible = !Camera.IsVisible;
        }


        private void inicio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());

        }



        private void Lanterna_Clicked(object sender, EventArgs e)
        {
            Camera.TorchOn = !Camera.TorchOn;
        }
    }
}
