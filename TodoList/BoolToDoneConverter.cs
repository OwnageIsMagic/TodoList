using System;
using System.Windows.Data;
using System.Globalization;

namespace TodoList
{
    class BoolToDoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (bool)value ? "✔" : "";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
