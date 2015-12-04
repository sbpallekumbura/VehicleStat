using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Util.GUI
{
    class Text2Boolean: IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Boolean s=false;
            string v = (string)value;
            if(Regex.IsMatch((string)value, "^[0-9A-Za-z]{1,3}[-][0-9]{3}"))
            {
                s = true;
            }
            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
