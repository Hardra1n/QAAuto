﻿using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Yandex
{
    public class YandexMailboxPage : BasePage, IMailboxPage
    {
        public const string URL = "https://mail.yandex.by/";

        private By _messageComposerButtonLocator = By.XPath("//a[contains(@class, 'mail-ComposeButton')]");


        public YandexMailboxPage(IWebDriver driver) : base(driver)
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }


        public IMessageReaderPage OpenNewMessageFromConcreteAuthor(string author)
        {
            By locator = By.XPath(GetNewMessageFromConcreteAuthorLocator(author));
            Waiters.WaitUntilDisplayElement(Driver, locator);
            Driver.FindElement(locator).Click();

            logger.Info($"Yandex user opened new message from {author}.");
            return new YandexMessageReaderPage(Driver);
        }

        public IMessageComposerPage OpenMessageComposer()
        {
            Waiters.WaitUntilDisplayElement(Driver, _messageComposerButtonLocator);
            Driver.FindElement(_messageComposerButtonLocator).Click();

            logger.Info("Yandex user navigated to message composer page.");
            return new YandexMessageComposerPage(Driver);
        }

        public IHomePage GoToHomePage()
        {
            Driver.Url = YandexHomePage.URL;

            logger.Info("Yandex user navigated to home page.");
            return new YandexHomePage(Driver);
        }

        private string GetNewMessageFromConcreteAuthorLocator(string author)
            => $"//a[.//*[contains(@title, '{author}')] and .//*[contains(@title, 'Отметить как прочитанное')]]";
    }
}
