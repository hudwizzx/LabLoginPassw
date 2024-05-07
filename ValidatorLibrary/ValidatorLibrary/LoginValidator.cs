using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ValidatorLibrary
{
    public interface IValidator
    {
        bool Validate(string? validateObject);
    }

    public class LoginValidator : IValidator
    {
        public bool Validate(string? validateObject)
        {
            if (string.IsNullOrWhiteSpace(validateObject))
                return false;

            // Проверка длины логина
            if (validateObject.Length < 6 || validateObject.Length > 16)
                return false;

            // Проверка на символы латиницы
            return validateObject.All(char.IsLetter);
        }
    }


}
