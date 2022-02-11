using ModelNService.Model;
using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruLoginPage : BasePage, ILoginPage
    {
        public const string URL = "https://account.mail.ru/";

        private string _afterLoginDriverTitle = "Почта Mail.ru";

        private By _usernameInputLocator = By.XPath("//input[@name='username']");

        private By _passwordInputLocator = By.XPath("//input[@name='password']");

        private By _submitLoginButtonLocator = By.XPath("//button[@type='submit']");

        private By _alertMessageLocator = By.XPath("//div[@data-test-id='error-footer-text']");


        public MailruLoginPage(IWebDriver driver) : base(driver)
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }


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
            Waiters.WaitUntilTitleContains(Driver, _afterLoginDriverTitle);

            logger.Info("Mailru user was authorized");
            return new MailruHomePage(Driver);
        }

        public ILoginPage SubmitLoginWithoutSwitchToNewPage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _submitLoginButtonLocator);
            Driver.FindElement(_submitLoginButtonLocator).Submit();
            return this;
        }

        public IHomePage LoginAs(User user) 
            => TypeUsername(user.Username).SubmitLoginWithoutSwitchToNewPage()
                                     .TypePassword(user.Password)
                                     .SubmitLogin();

        public string GetAlertMessageText()
        {
            Waiters.WaitUntilDisplayElement(Driver, _alertMessageLocator);
            return Driver.FindElement(_alertMessageLocator).Text;
        }
    }
}
