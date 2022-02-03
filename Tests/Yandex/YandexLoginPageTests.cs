using ModelNService.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Pages.Yandex;

namespace Tests.Yandex
{
    [TestFixture]
    public class YandexLoginPageTests
    {
        private YandexLoginPage _page;

        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = Driver.GetChromeDriver();
            _driver.Url = YandexLoginPage.URL;
            _page = new YandexLoginPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }

        [TestCase("12342321", "Такой логин не подойдет")]
        [TestCase("dsamksaldwasfwas", "Такого аккаунта нет")]
        [TestCase("", "Логин не указан")]
        public void CannotLoginWithIncorrectUsername(string username, string expectedAlertMessage)
        {
            string actualAlertMessage = _page.TypeUsername(username)
                                             .SubmitLoginWithoutSwitchToNewPage()
                                             .GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [TestCase("1234564321", "Неверный пароль")]
        [TestCase("", "Пароль не указан")]
        public void CannotLoginWithIncorrectPassword(string password, string expectedAlertMessage)
        {
            string actualAlertMessage = _page.TypeUsername(AccountProvider.GetUsername("Yandex"))
                                             .SubmitLoginWithoutSwitchToNewPage()
                                             .TypePassword(password)
                                             .SubmitLoginWithoutSwitchToNewPage()
                                             .GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [Test]
        public void LoginWithCorrectUsernameAndPassword()
        {
            string expectedDriverTitle = "Яндекс ID";
            
            _page.LoginAs(AccountProvider.GetUsername("Yandex"),
                          AccountProvider.GetPassword("Yandex"));
            bool isContains = Waiters.WaitUntilTitleContains(_driver, expectedDriverTitle);

            Assert.IsTrue(isContains);
        }

    }
}
