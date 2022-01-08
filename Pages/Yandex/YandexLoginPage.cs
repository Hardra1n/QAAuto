using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Yandex
{
    public class YandexLoginPage : ILoginPage
    {
        private By _usernameInput = By.XPath("//input[@name='login']");

        private By _passwordInput = By.XPath("//input[@name='passwd']");

        private By _submitLogin = By.XPath("//button[@type='submit']");

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
    }
}
