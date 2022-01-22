using OpenQA.Selenium;
using Pages.Interfaces;
using System;

namespace Pages.Yandex
{
    public class YandexLoginPage : ILoginPage
    {
        public static string url = "https://passport.yandex.by/";

        private By _usernameInput = By.XPath("//input[@name='login']");

        private By _passwordInput = By.XPath("//input[@name='passwd']");

        private By _submitLogin = By.XPath("//button[@type='submit']");

        private By _alertMessage = By.XPath("//div[@role = 'alert']");

        private string _pageTitle = "Авторизация";

        public YandexLoginPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebDriver Driver { get; set; }

        public IHomePage LoginAs(string username, string password)
        {
            TypeUsername(username);
            SubmitLoginWithoutSwitchToNewPage();
            TypePassword(password);
            return SubmitLogin();
        }

        public IHomePage SubmitLogin()
        {
            Waiters.WaitUntilDisplayElement(Driver, _submitLogin);
            Driver.FindElement(_submitLogin).Submit();
            return new YandexHomePage(Driver);
        }

        public ILoginPage SubmitLoginWithoutSwitchToNewPage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _submitLogin);
            Driver.FindElement(_submitLogin).Submit();
            return this;
        }

        public ILoginPage TypePassword(string password)
        {
            Waiters.WaitUntilDisplayElement(Driver, _passwordInput);
            Driver.FindElement(_passwordInput).SendKeys(password);
            return this;
        }

        public ILoginPage TypeUsername(string username)
        {
            Waiters.WaitUntilDisplayElement(Driver, _usernameInput);
            Driver.FindElement(_usernameInput).SendKeys(username);
            return this;
        }

        public string GetAlertMessageText()
        {
            Waiters.WaitUntilDisplayElement(Driver, _alertMessage);
            return Driver.FindElement(_alertMessage).Text;
        }
    }
}
