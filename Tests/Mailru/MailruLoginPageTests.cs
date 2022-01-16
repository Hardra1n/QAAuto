using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Pages.Mailru;
using System;

namespace Tests.Mailru
{
    [TestFixture]
    public class MailruLoginPageTests : BaseTest
    {
        MailruLoginPage _page;

        string _correctUsername = "khovan123456";

        string _correctPassword = "tiSpaOUrN33&";

        IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = GetNewChromeDriver();
            _driver.Url = "https://account.mail.ru/";
            _page = new MailruLoginPage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Close();
        }

        [TestCase("", "Поле «Имя аккаунта» должно быть заполнено")]
        [TestCase("fmwdklasnfkwjas", "Такой аккаунт не зарегистрирован")]
        public void CannotLoginWithIncorrectUsername(string username, string expectedAlertMessage)
        {
            _page.TypeUsername(username);
            _page.SubmitLoginWithoutSwitchToNewPage();
            string actualAlertMessage = _page.GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [TestCase("", "Поле «Пароль» должно быть заполнено")]
        [TestCase("dmwfkslawa", "Неверный пароль, попробуйте ещё раз")]
        public void CannotLoginWithIncorrectPassword(string password, string expectedAlertMessage)
        {
            _page.TypeUsername(_correctUsername);
            _page.SubmitLoginWithoutSwitchToNewPage();
            _page.TypePassword(password);
            _page.SubmitLoginWithoutSwitchToNewPage();
            string actualAlertMessage = _page.GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [Test]
        public void LoginWithCorrectUsernameAndPassword()
        {
            string titleHomepageSubstring = "Почта@Mail.Ru";

            _page.LoginAs(_correctUsername, _correctPassword);
            bool isContains = Waiters.WaitUntilTitleContains(_driver, titleHomepageSubstring);

            Assert.IsTrue(isContains);
        }
    }
}
