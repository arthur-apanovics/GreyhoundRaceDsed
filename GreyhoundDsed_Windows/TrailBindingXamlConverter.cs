using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace GreyhoundDsed_Windows
{
    class TrailBindingXamlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var num = System.Convert.ToDouble(value);

            return num - 25;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
