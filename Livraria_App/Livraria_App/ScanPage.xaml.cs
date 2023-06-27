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
            List<BarcodeResult> barcodeResults = e.BarcodeResults;
            bool isBarcodeInCenter = false;

            foreach (BarcodeResult barcodeResult in barcodeResults)
            {
                // Verificar se o centro do QR code está dentro da área desejada
                if (IsBarcodeCenterInArea(barcodeResult))
                {
                    isBarcodeInCenter = true;
                    break;
                }
            }

            if (isBarcodeInCenter)
            {
                string result = GetBarcodeResultString(barcodeResults);

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Result", result, "OK");
                    Camera.IsScanning = true;
                });
            }
        }

        private bool IsBarcodeCenterInArea(BarcodeResult barcodeResult)
        {
            // Obter o centro do QR code com base no retângulo delimitador
            double barcodeCenterX = barcodeResult.BoundingBox.Left + barcodeResult.BoundingBox.Width / 2;
            double barcodeCenterY = barcodeResult.BoundingBox.Top + barcodeResult.BoundingBox.Height / 2;

            // Obter as coordenadas do retângulo delimitador do Frame que contém o scanner
            double frameLeft = scannerFrame.Bounds.Left;
            double frameTop = scannerFrame.Bounds.Top;
            double frameWidth = scannerFrame.Bounds.Width;
            double frameHeight = scannerFrame.Bounds.Height;

            // Definir as margens da área central desejada em relação ao Frame
            double centerMarginX = frameWidth * 0.25;
            double centerMarginY = frameHeight * 0.25;

            // Definir a área central desejada dentro do Frame
            double centerXMin = frameLeft + centerMarginX;
            double centerXMax = frameLeft + frameWidth - centerMarginX;
            double centerYMin = frameTop + centerMarginY;
            double centerYMax = frameTop + frameHeight - centerMarginY;

            // Verificar se o centro do QR code está dentro da área central desejada
            return barcodeCenterX >= centerXMin && barcodeCenterX <= centerXMax &&
                   barcodeCenterY >= centerYMin && barcodeCenterY <= centerYMax;
        }

        private string GetBarcodeResultString(List<BarcodeResult> barcodeResults)
        {
            string result = string.Empty;

            foreach (BarcodeResult barcodeResult in barcodeResults)
            {
                result += $"Type: {barcodeResult.BarcodeType}, Value: {barcodeResult.DisplayValue}{Environment.NewLine}";
            }

            return result;
        }

        private void ZoomIn_Clicked(object sender, EventArgs e)
        {
            ZoomCamera(1.2f);
        }

        private void ZoomOut_Clicked(object sender, EventArgs e)
        { 
            if (Camera.Scale > 1.2)
            {
              ZoomCamera(0.8f);
            }
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
    }
}
