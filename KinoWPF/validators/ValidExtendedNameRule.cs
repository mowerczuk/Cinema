﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KinoWPF.validators
{
    class ValidExtendedNameRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = value as string;

            if (name == null || name == "")
            {
                return new ValidationResult(true, null);
            }
            else
            {
                if (Regex.IsMatch(name, @"^[a-zA-ZąćęłśźżóńĄĆĘŁŚŹŻÓŃ,\-.' ]+$"))
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "Illegal characters!");
                }
            }
        }
    }
}
