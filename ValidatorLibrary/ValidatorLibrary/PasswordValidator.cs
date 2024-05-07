using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidatorLibrary
{
    public class PasswordValidator : IValidator
    {
        public bool Validate(string? validateObject)
        {
            if (string.IsNullOrWhiteSpace(validateObject))
                return false;

            // Проверка длины пароля
            if (validateObject.Length < 8 || validateObject.Length > 20)
                return false;

            // Проверка на символы латиницы, цифры и спец. знаки
            if (!Regex.IsMatch(validateObject, @"^[a-zA-Z0-9!@#$%^&*-_]+$"))
                return false;

            // Проверка на наличие хотя бы одной заглавной буквы, цифры и спец. знака
            return validateObject.Any(char.IsUpper) && validateObject.Any(char.IsDigit) && validateObject.Any(IsSpecialChar);
        }

        private bool IsSpecialChar(char c)
        {
            return "!@#$%^&*-_".Contains(c);
        }
    }
}
