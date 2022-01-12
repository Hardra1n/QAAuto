﻿using OpenQA.Selenium;
using Pages.Interfaces;
using System;
using System.Threading;

namespace Pages.Yandex
{
    public class YandexHomePage : IHomePage
    {
        By _buttonToMailbox = By.XPath("//ul[@class = 'menu__group']/li[1]/a");

        By _buttonToOpenMenubar = By.XPath("//a[@target='_parent']");

        public YandexHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        private IHomePage OpenMenubar()
        {
            Waiters.WaitUntilDisplayElement(Driver, _buttonToOpenMenubar);
            Driver.FindElement(_buttonToOpenMenubar).Click();
            return this;
            
        }

        public IMailboxPage GoToMailboxPage()
        {
            OpenMenubar();
            Waiters.WaitUntilDisplayElement(Driver, _buttonToMailbox);
            Driver.FindElement(_buttonToMailbox).Click();
            return new YandexMailboxPage(Driver);
        }
    }
}
