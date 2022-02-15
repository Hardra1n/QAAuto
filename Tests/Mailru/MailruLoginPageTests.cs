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

        [TestCase("", "Поле «Имя аккаунта» должно быть заполнено", "The \"Account name\" field is required")]
        [TestCase("fmwdklasnfkwjas", "Такой аккаунт не зарегистрирован", "That account is not registered")]
        public void CannotLoginWithIncorrectUsername(string username, params string[] expectedAlertMessages)
        {
            try
            {
                string actualAlertMessage = _page.TypeUsername(username)
                                                 .SubmitLoginWithoutSwitchToNewPage()
                                                 .GetAlertMessageText();

                bool isEquals = actualAlertMessage.AreEqual(expectedAlertMessages);
                Assert.IsTrue(isEquals, actualAlertMessage + '/' + expectedAlertMessages);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message + '\n' + ex.StackTrace);
            }
        }

        [TestCase("", "Поле «Пароль» должно быть заполнено", "The \"Password\" field is required")]
        [TestCase("dmwfkslawa", "Неверный пароль, попробуйте ещё раз", "Incorrect password. Try again")]
        public void CannotLoginWithIncorrectPassword(string password, params string[] expectedAlertMessages)
        {
            try
            {
                string actualAlertMessage = _page.TypeUsername(accounts.Mailru.Username)
                                                 .SubmitLoginWithoutSwitchToNewPage()
                                                 .TypePassword(password)
                                                 .SubmitLoginWithoutSwitchToNewPage()
                                                 .GetAlertMessageText();
                bool isEquals = actualAlertMessage.AreEqual(expectedAlertMessages);
                Assert.IsTrue(isEquals, actualAlertMessage + '/' + expectedAlertMessages);
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
