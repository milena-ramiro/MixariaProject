using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace ProjectMixaria.Util
{
    public class ByteArrayToImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            var ByteArray = value as byte[];
            Stream stream = new MemoryStream(ByteArray);
            ImageSource ImageSrc = ImageSource.FromStream(() => stream);
            return ImageSrc;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
