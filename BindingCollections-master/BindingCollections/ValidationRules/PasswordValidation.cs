using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BindingCollections.ValidationRules
{
    public class PasswordValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input == string.Empty)
            {
                return new ValidationResult(false, "Ввод информации в поле обязателен");
            }
            if (input.Length <= 6)
            {
                return new ValidationResult(false, "Длина пароля должна быть не менее 6 символов");
            }

            bool isDigital = false;
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    isDigital = true;
                    break;
                }
            }

            bool isSymbol = false;
            foreach (char c in input)
            {
                if (char.IsSymbol(c))
                {
                    isSymbol = true;
                    break;
                }
            }

            if (!isDigital)
            {
                return new ValidationResult(false, "В пароле должна находится хотя бы одна цифра");
            }

            if (!isSymbol)
            {
                return new ValidationResult(false, "В пароле должен находится хотя бы один символ");
            }

            return ValidationResult.ValidResult;
        }

    }
}
