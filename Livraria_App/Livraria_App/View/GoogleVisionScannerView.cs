using GoogleVisionBarCodeScanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Livraria_App.View
{
    public class GoogleVisionScannerView : ContentView
    {
        public delegate void ScanResultDelegate(BarcodeResult result);
        public event ScanResultDelegate OnScanResult;

        public event Action AutoFocusRequested;

        public GoogleVisionScannerView()
        {
                VerticalOptions = LayoutOptions.FillAndExpand;
                HorizontalOptions = LayoutOptions.FillAndExpand;
           
        }

        public void RaiseScanResult(BarcodeResult result)
        {
            Result = result;
            OnScanResult?.Invoke(Result);
            ScanResultCommand?.Execute(Result);
        }

        public void AutoFocus()
            => AutoFocusRequested?.Invoke();

        public static readonly BindableProperty IsScanningProperty =
            BindableProperty.Create(nameof(IsScanning), typeof(bool), typeof(GoogleVisionScannerView), false);

        public bool IsScanning
        {
            get => (bool)GetValue(IsScanningProperty);
            set => SetValue(IsScanningProperty, value);
        }

        public static readonly BindableProperty ResultProperty =
            BindableProperty.Create(nameof(Result), typeof(BarcodeResult), typeof(GoogleVisionScannerView), default(BarcodeResult));
        public BarcodeResult Result
        {
            get => (BarcodeResult)GetValue(ResultProperty);
            set => SetValue(ResultProperty, value);
        }

        public static readonly BindableProperty ScanResultCommandProperty =
            BindableProperty.Create(nameof(ScanResultCommand), typeof(ICommand), typeof(GoogleVisionScannerView), default(ICommand));
        public ICommand ScanResultCommand
        {
            get => (ICommand)GetValue(ScanResultCommandProperty);
            set => SetValue(ScanResultCommandProperty, value);
        }
    }
}