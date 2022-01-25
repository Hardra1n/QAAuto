using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruLoginPage : BasePage, ILoginPage
    {
        public static string url = "https://account.mail.ru/";

        By _usernameInputLocator = By.XPath("//input[@name='username']");

        By _passwordInputLocator = By.XPath("//input[@name='password']");

        By _submitLoginButtonLocator = By.XPath("//button[@type='submit']");

        By _alertMessageLocator = By.XPath("//div[@data-test-id='error-footer-text']");


        public MailruLoginPage(IWebDriver driver) : base(driver) { }


        public ILoginPage TypeUsername(string username)
        {
            Waiters.WaitUntilDisplayElement(Driver, _usernameInputLocator);
            Driver.FindElement(_usernameInputLocator).SendKeys(username);
            return this;
        }
        public ILoginPage TypePassword(string password)
        {
            Waiters.WaitUntilDisplayElement(Driver, _passwordInputLocator);
            Driver.FindElement(_passwordInputLocator).SendKeys(password);
            return this;
        }

        public IHomePage SubmitLogin()
        {
            Waiters.WaitUntilDisplayElement(Driver, _submitLoginButtonLocator);
            Driver.FindElement(_submitLoginButtonLocator).Submit();
            return new MailruHomePage(Driver);
        }

        public ILoginPage SubmitLoginWithoutSwitchToNewPage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _submitLoginButtonLocator);
            Driver.FindElement(_submitLoginButtonLocator).Submit();
            return this;
        }

        public IHomePage LoginAs(string username, string password)
        {
            TypeUsername(username);
            SubmitLoginWithoutSwitchToNewPage();
            TypePassword(password);
            return SubmitLogin();
        }

        public string GetAlertMessageText()
        {
            Waiters.WaitUntilDisplayElement(Driver, _alertMessageLocator);
            return Driver.FindElement(_alertMessageLocator).Text;
        }
    }
}
