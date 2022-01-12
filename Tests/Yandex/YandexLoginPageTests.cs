using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages.Interfaces;
using Pages.Yandex;

namespace Tests.Yandex
{
    [TestFixture]
    public class YandexLoginPageTests
    {
        private YandexLoginPage _page;

        private string _correctUsername = "kirylkho123456";

        private string _correctPassword = "Qwerty1231";

        IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://passport.yandex.by/";
            _page = new YandexLoginPage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Close();
        }

        [Test]
        public void LoginWithInccorrectUsername()
        {
            throw new System.NotImplementedException();
        }

    }
}
