using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pages.Interfaces;

namespace Pages.Yandex
{
    public class YandexHomePage : BasePage, IHomePage
    {
        public const string URL = "https://passport.yandex.by/profile";

        public const string pageTitle = "Яндекс ID";

        private By _buttonToMailboxLocator = By.XPath("//ul[@class = 'menu__group']/li[1]/a");

        private By _buttonToOpenMenubarLocator = By.XPath("//a[@target='_parent']");

        private By _displayNameWindowButtonLocator = By.XPath("//*[@class='AdditionalPersonalInfo-name']//a");

        private By _nicknameSelectorLocator = By.XPath("//select");

        private By _nicknameInputLocator = By.XPath("//input[@name = 'display_name']");

        private By _displaynameSaveButtonLocator = By.XPath("//*[contains(text(), 'Сохранить')]/ancestor::button");

        private By _nicknameTextLocator = By.XPath("//*[contains(@class, 'personal-info__displayname')]");


        public YandexHomePage(IWebDriver driver) : base(driver)
        {
            Waiters.WaitUntilTitleEquals(Driver, pageTitle);
        }

        public IMailboxPage GoToMailboxPage()
        {
            OpenMenubar();
            Waiters.WaitUntilDisplayElement(Driver, _buttonToMailboxLocator);
            Driver.FindElement(_buttonToMailboxLocator).Click();
            return new YandexMailboxPage(Driver);
        }

        public IHomePage ChangeNickname(string nickname)
        {
            OpenDisplayNameWindow();
            SelectAnotherDisplayName();
            PutDisplayName(nickname);
            return SaveDisplayName();
        }

        public string GetNickname()
        {
            Waiters.WaitUntilDisplayElement(Driver, _nicknameTextLocator);
            return Driver.FindElement(_nicknameTextLocator).Text;
        }

        private IHomePage OpenMenubar()
        {
            Waiters.WaitUntilDisplayElement(Driver, _buttonToOpenMenubarLocator);
            Driver.FindElement(_buttonToOpenMenubarLocator).Click();
            return this;
        }

        private IHomePage MoveCoursorToShowAdditionalWindows()
        {
            Waiters.WaitUntilDisplayElement(Driver, _nicknameTextLocator);
            new Actions(Driver).MoveToElement(Driver.FindElement(_nicknameTextLocator)).Perform();
            return this;
        }

        private IHomePage OpenDisplayNameWindow()
        {
            MoveCoursorToShowAdditionalWindows();
            Waiters.WaitUntilDisplayElement(Driver, _displayNameWindowButtonLocator);
            Driver.FindElement(_displayNameWindowButtonLocator).Click();
            return this;
        }

        private IHomePage SelectAnotherDisplayName()
        {
            SelectElement selectElement = new SelectElement(Driver.FindElement(_nicknameSelectorLocator));
            selectElement.SelectByValue("ANOTHER");
            return this;
        }

        private IHomePage PutDisplayName(string nickname)
        {
            Waiters.WaitUntilDisplayElement(Driver, _nicknameInputLocator);
            var element = Driver.FindElement(_nicknameInputLocator);
            element.SendKeys(Keys.Control + 'a' + Keys.Delete);
            element.SendKeys(nickname);
            return this;
        }

        private IHomePage SaveDisplayName()
        {
            Waiters.WaitUntilDisplayElement(Driver, _displaynameSaveButtonLocator);
            Driver.FindElement(_displaynameSaveButtonLocator).Click();
            Waiters.WaitUntilNotVisable(Driver, _displaynameSaveButtonLocator);
            return this;
        }

    }
}
