using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Pages.Yandex;

namespace Tests.Yandex
{
    [TestFixture]
    public class YandexLoginPageTests : BaseTest
    {
        private YandexLoginPage _page;

        IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = GetNewChromeDriver();
            _driver.Url = "https://passport.yandex.by/";
            _page = new YandexLoginPage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Close();
        }

        [TestCase("12342321", "Такой логин не подойдет")]
        [TestCase("dsamksaldwasfwas", "Такого аккаунта нет")]
        [TestCase("", "Логин не указан")]
        public void CannotLoginWithIncorrectUsername(string username, string expectedAlertMessage)
        {
            _page.TypeUsername(username).SubmitLoginWithoutSwitchToNewPage();
            string actualAlertMessage = _page.GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [TestCase("1234564321", "Неверный пароль")]
        [TestCase("", "Пароль не указан")]
        public void CannotLoginWithIncorrectPassword(string password, string expectedAlertMessage)
        {
            _page.TypeUsername(AccountCredenitals.yandexLogin).SubmitLoginWithoutSwitchToNewPage();
            _page.TypePassword(password).SubmitLoginWithoutSwitchToNewPage();
            string actualAlertMessage = _page.GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [Test]
        public void LoginWithCorrectUsernameAndPassword()
        {
            string expectedDriverTitle = "Яндекс ID";
            
            _page.LoginAs(AccountCredenitals.yandexLogin, AccountCredenitals.yandexPassword);
            bool isContains = Waiters.WaitUntilTitleContains(_driver, expectedDriverTitle);

            Assert.IsTrue(isContains);
        }

    }
}
