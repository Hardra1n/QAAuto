using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Pages.Mailru;
using System;
using System.Threading;

namespace Tests.Mailru
{
    [TestFixture]
    public class MailruLoginPageTests
    {
        private MailruLoginPage _page;

        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = Driver.GetChromeDriver();
            _driver.Url = MailruLoginPage.url;
            _page = new MailruLoginPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
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
            string actualAlertMessage = _page.TypeUsername(AccountCredenitals.mailruLogin)
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

            _page.LoginAs(AccountCredenitals.mailruLogin, AccountCredenitals.mailruPassword);
            bool isContains = Waiters.WaitUntilTitleContains(_driver, titleHomepageSubstring);

            Assert.IsTrue(isContains);
        }
    }
}
