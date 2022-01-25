using OpenQA.Selenium;
using Pages.Interfaces;
using System;

namespace Pages.Yandex
{
    public class YandexLoginPage : BasePage, ILoginPage
    {
        public static string url = "https://passport.yandex.by/";

        By _usernameInputLocator = By.XPath("//input[@name='login']");

        By _passwordInputLocator = By.XPath("//input[@name='passwd']");

        By _submitLoginLocator = By.XPath("//button[@type='submit']");

        By _alertMessageLocator = By.XPath("//div[@role = 'alert']");


        public YandexLoginPage(IWebDriver driver) : base(driver) { }


        public IHomePage LoginAs(string username, string password)
        {
            TypeUsername(username);
            SubmitLoginWithoutSwitchToNewPage();
            TypePassword(password);
            return SubmitLogin();
        }

        public IHomePage SubmitLogin()
        {
            Waiters.WaitUntilDisplayElement(Driver, _submitLoginLocator);
            Driver.FindElement(_submitLoginLocator).Submit();
            return new YandexHomePage(Driver);
        }

        public ILoginPage SubmitLoginWithoutSwitchToNewPage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _submitLoginLocator);
            Driver.FindElement(_submitLoginLocator).Submit();
            return this;
        }

        public ILoginPage TypePassword(string password)
        {
            Waiters.WaitUntilDisplayElement(Driver, _passwordInputLocator);
            Driver.FindElement(_passwordInputLocator).SendKeys(password);
            return this;
        }

        public ILoginPage TypeUsername(string username)
        {
            Waiters.WaitUntilDisplayElement(Driver, _usernameInputLocator);
            Driver.FindElement(_usernameInputLocator).SendKeys(username);
            return this;
        }

        public string GetAlertMessageText()
        {
            Waiters.WaitUntilDisplayElement(Driver, _alertMessageLocator);
            return Driver.FindElement(_alertMessageLocator).Text;
        }
    }
}
