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
            new object[] { "user", false },           // ������ ����������� �����
            new object[] { "username", true },        // �������� �����
            new object[] { "user_name_with_numbers", false },  // �������� ������������ �������
            new object[] { "usernameveryverylong", false },    // ������ ������������ �����
            new object[] { null, false }              // ������ ��������
        };

        public static object[] PasswordCases =
        {
            new object[] { "pass", false },           // ������ ����������� �����
            new object[] { "password1!", false },     // ��� ��������� �����
            new object[] { "Password1!", true },      // �������� ������
            new object[] { "pass_with_long_password", false },  // ������ ������������ �����
            new object[] { "passwordwithoutspecialchar", false }, // ��� ����. �������
            new object[] { null, false }              // ������ ��������
        };
    }
}
