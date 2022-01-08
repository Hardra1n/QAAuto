using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Yandex
{
    public class YandexHomePage : IHomePage
    {
        string _urlToMailBox;

        public YandexHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMailboxPage GoToMailboxPage()
        {
            throw new NotImplementedException();
        }
    }
}
