using ModelNService.Driver;
using ModelNService.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Pages.Yandex;

namespace Tests.Yandex
{
    [TestFixture]
    [Category("All")]
    public class YandexLoginPageTests : BaseTest
    {
        private YandexLoginPage _page;

        [SetUp]
        public void SetUp()
        {
            _driver = DriverManager.GetWebDriver();
            _driver.Url = YandexLoginPage.URL;
            _page = new YandexLoginPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            DriverManager.CloseDriver();
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
            string actualAlertMessage = _page.TypeUsername(accounts.Yandex.Username)
                                             .SubmitLoginWithoutSwitchToNewPage()
                                             .TypePassword(password)
                                             .SubmitLoginWithoutSwitchToNewPage()
                                             .GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [Test]
        [Category("Smoke")]
        public void LoginWithCorrectUsernameAndPassword()
        {
            string expectedDriverTitle = "Яндекс ID";
            
            _page.LoginAs(accounts.Yandex);
            bool isContains = Waiters.WaitUntilTitleContains(_driver, expectedDriverTitle);

            Assert.IsTrue(isContains);
        }

    }
}
