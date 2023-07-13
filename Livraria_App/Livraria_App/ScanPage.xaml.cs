using BarcodeScanner.Mobile;
using Livraria_App.View;
using System;
using System.Collections.Generic;
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
            BarcodeScanner.Mobile.Methods.AskForRequiredPermission();

        }

        private void Camera_OnDetected(object sender, OnDetectedEventArg e)
        {
            List<BarcodeResult> obj = e.BarcodeResults;

            string result = string.Empty;
            for (int i = 0; i < obj.Count; i++)
            {
                result += $"Type: {obj[i].BarcodeType}, Value: {obj[i].DisplayValue}{Environment.NewLine}";
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
            ZoomSlider.Value = Camera.Scale;
        }

        private void ZoomOut_Clicked(object sender, EventArgs e)
        {
            if (Camera.Scale > 0.8f)
            {
                ZoomCamera(0.8f);
                ZoomSlider.Value = Camera.Scale;
            }
        }

        private void ZoomSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double sliderValue = e.NewValue;
            // double zoomValue = CustomScalingFunction(sliderValue);
            double zoomValue = 0.8 + (0.4 * sliderValue);

            ZoomCamera((float)zoomValue);
        }

        private double CustomScalingFunction(double value)
        {
            double scaleFactor = 2;
            double scaledValue = Math.Pow(scaleFactor, value);

            return scaledValue;
        }

        private void ZoomCamera(float zoom)
        {
            float currentScale = (float)Camera.Scale;
            float targetScale = currentScale * zoom;
            float incrementalZoom = (targetScale - currentScale) / 10;

            for (int i = 0; i < 10; i++)
            {
                currentScale += incrementalZoom;
                Camera.Scale = currentScale;
                //Task.Delay(50))
            }
        }



        private void LerQRCode_Clicked(object sender, EventArgs e)
        {
            Camera.IsVisible = !Camera.IsVisible;
        }

        private void Lanterna_Clicked(object sender, EventArgs e)
        {
            Camera.TorchOn = !Camera.TorchOn;
        }

    }
}
