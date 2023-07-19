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
            float targetScale = (float)Camera.Scale * 1.2f;
            ApplyZoom(targetScale);
        }

        private void ZoomOut_Clicked(object sender, EventArgs e)
        {
            float targetScale = (float)Camera.Scale * 0.8f;
            if (targetScale > 0.8f)
                ApplyZoom(targetScale);
        }

        private void ZoomSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            float targetScale = (float)e.NewValue * 4.2f + 0.8f;
            ApplyZoom(targetScale);
        }

        private void ApplyZoom(float targetScale)
        {
            Camera.Scale = targetScale;
            ZoomSlider.Value = (Camera.Scale - 0.8) / 4.2;
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
