using ModelNService.Driver;
using ModelNService.Model;
using ModelNService.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Pages.Mailru;

namespace Tests.Mailru
{
    [TestFixture]
    public class MailruLoginPageTests : BaseTest
    {
        private MailruLoginPage _page;

        [SetUp]
        public void SetUp()
        {
            _driver = DriverManager.GetWebDriver();
            _driver.Url = MailruLoginPage.URL;
            _page = new MailruLoginPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            DriverManager.CloseDriver();
        }

        [TestCase("", "Поле «Имя аккаунта» должно быть заполнено")]
        [TestCase("fmwdklasnfkwjas", "Такой аккаунт не зарегистрирован")]
        public void CannotLoginWithIncorrectUsername(string username, string expectedAlertMessage)
        {
            string actualAlertMessage = _page.TypeUsername(username)
                                             .SubmitLoginWithoutSwitchToNewPage()
                                             .GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [TestCase("", "Поле «Пароль» должно быть заполнено")]
        [TestCase("dmwfkslawa", "Неверный пароль, попробуйте ещё раз")]
        public void CannotLoginWithIncorrectPassword(string password, string expectedAlertMessage)
        {
            string actualAlertMessage = _page.TypeUsername(accounts.Mailru.Username)
                                             .SubmitLoginWithoutSwitchToNewPage()
                                             .TypePassword(password)
                                             .SubmitLoginWithoutSwitchToNewPage()
                                             .GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [Test]
        public void LoginWithCorrectUsernameAndPassword()
        {
            string titleHomepageSubstring = "Почта Mail.ru";

            _page.LoginAs(accounts.Mailru);
            bool isContains = Waiters.WaitUntilTitleContains(_driver, titleHomepageSubstring);

            Assert.IsTrue(isContains);
        }
    }
}
