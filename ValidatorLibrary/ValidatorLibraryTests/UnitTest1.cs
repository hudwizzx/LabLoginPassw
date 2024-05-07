using NUnit.Framework;
using ValidatorLibrary;

namespace ValidatorLibraryTests
{
    public class ValidatorTests
    {
        [Test]
        [TestCaseSource(typeof(ValidatorTestData), nameof(ValidatorTestData.LoginCases))]
        public void LoginValidator_Test(string login, bool expectedResult)
        {
            var validator = new LoginValidator();
            var result = validator.Validate(login);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCaseSource(typeof(ValidatorTestData), nameof(ValidatorTestData.PasswordCases))]
        public void PasswordValidator_Test(string password, bool expectedResult)
        {
            var validator = new PasswordValidator();
            var result = validator.Validate(password);
            Assert.AreEqual(expectedResult, result);
        }
    }

    public class ValidatorTestData
    {
        public static object[] LoginCases =
        {
            new object[] { "user", false },           // Меньше минимальной длины
            new object[] { "username", true },        // Валидный логин
            new object[] { "user_name_with_numbers", false },  // Содержит недопустимые символы
            new object[] { "usernameveryverylong", false },    // Больше максимальной длины
            new object[] { null, false }              // Пустое значение
        };

        public static object[] PasswordCases =
        {
            new object[] { "pass", false },           // Меньше минимальной длины
            new object[] { "password1!", false },     // Нет заглавной буквы
            new object[] { "Password1!", true },      // Валидный пароль
            new object[] { "pass_with_long_password", false },  // Больше максимальной длины
            new object[] { "passwordwithoutspecialchar", false }, // Нет спец. символа
            new object[] { null, false }              // Пустое значение
        };
    }
}
