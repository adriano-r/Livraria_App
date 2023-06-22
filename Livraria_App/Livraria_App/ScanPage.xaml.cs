using Android.Hardware.Camera2;
using GoogleVisionBarCodeScanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
