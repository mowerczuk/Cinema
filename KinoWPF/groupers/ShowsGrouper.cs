using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KinoWPF
{
    public class ShowsGrouper : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan startTime = (TimeSpan)value;
            int interval = startTime.Hours / 4;
            int lowerLimit = interval * 4;
            int upperLimit = (interval + 1) * 4;            if (lowerLimit < 10)
            {
                lowerLimit = 10;
            }            if(upperLimit > 22)
            {
                upperLimit = 22;
            }            TimeSpan lower = new TimeSpan(lowerLimit, 0, 0);
            TimeSpan upper = new TimeSpan(upperLimit, 0, 0);
            return string.Format("{0:hh\\:mm} - {1:hh\\:mm}", lower, upper);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
