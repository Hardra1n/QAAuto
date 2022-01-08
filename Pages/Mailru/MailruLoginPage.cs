using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruLoginPage : ILoginPage
    {
        private By _usernameInput = By.XPath("//input[@name='username']");

        private By _passwordInput = By.XPath("//input[@name='password']");

        private By _submitLoginButton = By.XPath("//button[@type='submit']");

        public MailruLoginPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public ILoginPage TypeUsername(string username)
        {
            Waiters.WaitUntilDisplayElement(Driver, _usernameInput);
            Driver.FindElement(_usernameInput).SendKeys(username);
            return this;
        }
        public ILoginPage TypePassword(string password)
        {
            Waiters.WaitUntilDisplayElement(Driver, _passwordInput);
            Driver.FindElement(_passwordInput).SendKeys(password);
            return this;
        }

        public IHomePage SubmitLogin()
        {
            Waiters.WaitUntilDisplayElement(Driver, _submitLoginButton);
            Driver.FindElement(_submitLoginButton).Submit();
            return new MailruHomePage(Driver);
        }

        public ILoginPage SubmitLoginWithoutSwitchToNewPage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _submitLoginButton);
            Driver.FindElement(_submitLoginButton).Submit();
            return this;
        }

        public IHomePage LoginAs(string username, string password)
        {
            TypeUsername(username);
            SubmitLoginWithoutSwitchToNewPage();
            TypePassword(password);
            return SubmitLogin();
        }
    }
}
