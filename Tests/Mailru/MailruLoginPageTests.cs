using ModelNService.Driver;
using ModelNService.Model;
using ModelNService.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Pages.Mailru;
using System;

namespace Tests.Mailru
{
    [TestFixture]
    [Category("All")]
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
            HandleTestFailure();
            DriverManager.CloseDriver();
        }

        [TestCase("", "Поле «Имя аккаунта» должно быть заполнено")]
        [TestCase("fmwdklasnfkwjas", "Такой аккаунт не зарегистрирован")]
        public void CannotLoginWithIncorrectUsername(string username, string expectedAlertMessage)
        {
            try
            {
                string actualAlertMessage = _page.TypeUsername(username)
                                                 .SubmitLoginWithoutSwitchToNewPage()
                                                 .GetAlertMessageText();

                Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message + '\n' + ex.StackTrace);
            }
        }

        [TestCase("", "Поле «Пароль» должно быть заполнено")]
        [TestCase("dmwfkslawa", "Неверный пароль, попробуйте ещё раз")]
        public void CannotLoginWithIncorrectPassword(string password, string expectedAlertMessage)
        {
            try
            {
                string actualAlertMessage = _page.TypeUsername(accounts.Mailru.Username)
                                                 .SubmitLoginWithoutSwitchToNewPage()
                                                 .TypePassword(password)
                                                 .SubmitLoginWithoutSwitchToNewPage()
                                                 .GetAlertMessageText();

                Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message + '\n' + ex.StackTrace);
            }
        }

        [Test]
        [Category("Smoke")]
        public void LoginWithCorrectUsernameAndPassword()
        {
            try
            {
                string titleHomepageSubstring = "Почта Mail.ru";

                _page.LoginAs(accounts.Mailru);
                bool isContains = Waiters.WaitUntilTitleContains(_driver, titleHomepageSubstring);

                Assert.IsTrue(isContains);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message + '\n' + ex.StackTrace);
            }
        }
    }
}
