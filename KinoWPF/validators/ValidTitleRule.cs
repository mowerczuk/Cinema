using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KinoWPF
{
    public class ValidTitleRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = value as string;

            if (name == null || name == "")
            {
                return new ValidationResult(false, "Can't be left empty!");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
