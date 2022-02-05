using OpenQA.Selenium;
using Pages.Interfaces;
using ModelNService.Model;

namespace Pages.Yandex
{
    public class YandexLoginPage : BasePage, ILoginPage
    {
        public static string URL = "https://passport.yandex.by/";

        private By _usernameInputLocator = By.XPath("//input[@name='login']");

        private By _passwordInputLocator = By.XPath("//input[@name='passwd']");

        private By _submitLoginLocator = By.XPath("//button[@type='submit']");

        private By _alertMessageLocator = By.XPath("//div[@role = 'alert']");


        public YandexLoginPage(IWebDriver driver) : base(driver) { }


        public IHomePage LoginAs(User user) 
            => TypeUsername(user.Username).SubmitLoginWithoutSwitchToNewPage()
                                     .TypePassword(user.Password)
                                     .SubmitLogin();
        

        public IHomePage SubmitLogin()
        {
            Waiters.WaitUntilDisplayElement(Driver, _submitLoginLocator);
            Driver.FindElement(_submitLoginLocator).Submit();
            Waiters.WaitUntilTitleContains(Driver, YandexHomePage.pageTitle);
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
