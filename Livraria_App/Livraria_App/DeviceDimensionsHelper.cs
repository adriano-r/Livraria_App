using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Livraria_App
{
    class DeviceDimensionsHelper
    {
        public static double ScaledWidth => GetScaledWidth(0.9);
        public static double ScaledHeight => GetScaledHeight(0.4);

        private static double GetScaledWidth(double scale)
        {
            var deviceWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
            return Convert.ToInt32(Math.Round(deviceWidth * scale));
        }

        private static double GetScaledHeight(double scale)
        {
            var deviceHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
            return Convert.ToInt32(Math.Round(deviceHeight * scale));
        }
    }
}
