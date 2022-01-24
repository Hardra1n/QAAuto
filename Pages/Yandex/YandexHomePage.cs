using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pages.Interfaces;
using System;
using System.Threading;

namespace Pages.Yandex
{
    public class YandexHomePage : IHomePage
    {
        By _buttonToMailbox = By.XPath("//ul[@class = 'menu__group']/li[1]/a");

        By _buttonToOpenMenubar = By.XPath("//a[@target='_parent']");

        By _displayNameWindowButton = By.XPath("//*[@class='AdditionalPersonalInfo-name']//a");

        By _nicknameSelector = By.XPath("//select[@name = 'displayname']");

        By _nicknameInput = By.XPath("//input[@name = 'display_name']");

        By _displaynameSaveButton = By.XPath("//*[contains(text(), 'Сохранить')]/ancestor::button");

        By _nicknameText = By.XPath("//*[contains(@class, 'personal-info__displayname')]");

        By _tempLocator = By.XPath("//div[@class='AdditionalPersonalInfo-name']");

        public static string url = "https://passport.yandex.by/profile";

        string _pageTitle = "Яндекс ID";

        public YandexHomePage(IWebDriver driver)
        {
            Driver = driver;
            Waiters.WaitUntilTitleEquals(Driver, _pageTitle);
        }

        IWebDriver Driver { get; set; }

        private IHomePage OpenMenubar()
        {
            Waiters.WaitUntilDisplayElement(Driver, _buttonToOpenMenubar);
            Driver.FindElement(_buttonToOpenMenubar).Click();
            return this;
        }

        private IHomePage MoveCoursorToShowAdditionalWindows()
        {
            Waiters.WaitUntilDisplayElement(Driver, _tempLocator);
            new Actions(Driver).MoveToElement(Driver.FindElement(_nicknameText)).Perform();
            return this;
        }

        private IHomePage OpenDisplayNameWindow()
        {
            MoveCoursorToShowAdditionalWindows();
            Waiters.WaitUntilDisplayElement(Driver, _displayNameWindowButton);
            Driver.FindElement(_displayNameWindowButton).Click();
            return this;
        }

        private IHomePage SelectAnotherDisplayName()
        {
            Waiters.WaitUntilDisplayElement(Driver, _nicknameSelector);
            SelectElement selectElement = new SelectElement(Driver.FindElement(_nicknameSelector));
            selectElement.SelectByValue("ANOTHER");
            return this;
        }

        private IHomePage PutDisplayName(string nickname)
        {
            Waiters.WaitUntilDisplayElement(Driver, _nicknameInput);
            var element = Driver.FindElement(_nicknameInput);
            element.SendKeys(Keys.Control + 'a' + Keys.Delete);
            element.SendKeys(nickname);
            return this;
        }

        private IHomePage SaveDisplayName()
        {
            Waiters.WaitUntilDisplayElement(Driver, _displaynameSaveButton);
            Driver.FindElement(_displaynameSaveButton).Click();
            Waiters.WaitUntilNotVisable(Driver, _displaynameSaveButton);
            return this;
        }

        public IMailboxPage GoToMailboxPage()
        {
            OpenMenubar();
            Waiters.WaitUntilDisplayElement(Driver, _buttonToMailbox);
            Driver.FindElement(_buttonToMailbox).Click();
            return new YandexMailboxPage(Driver);
        }

        public IHomePage ChangeNickname(string nickname)
        {
            OpenDisplayNameWindow();
            //SelectAnotherDisplayName();
            PutDisplayName(nickname);
            return SaveDisplayName();
        }

        public string GetNickname()
        {
            Waiters.WaitUntilDisplayElement(Driver, _nicknameText);
            return Driver.FindElement(_nicknameText).Text;
        }
    }
}
