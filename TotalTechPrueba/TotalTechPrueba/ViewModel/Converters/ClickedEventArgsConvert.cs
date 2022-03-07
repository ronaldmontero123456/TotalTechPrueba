using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TotalTechPrueba.ViewModel.Converters
{
    class ClickedEventArgsConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as ClickedEventArgs;
            if (eventArgs == null)
                throw new ArgumentException("Este no es un TextChangedEventArgs", "value");

            return eventArgs.Parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
