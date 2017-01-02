using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PROG5_LeagueOfNinjas.Validation
{
    public class IntLowerThan1ValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                return new ValidationResult(int.Parse(value.ToString()) >= 1, "Dit moet hoger dan 0 zijn!");
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Dit is geen geldig getal!");
            }
        }
    }
}
