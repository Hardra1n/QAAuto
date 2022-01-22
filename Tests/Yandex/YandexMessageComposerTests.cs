using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Yandex;

namespace Tests.Yandex
{
    [TestFixture]
    public class YandexMessageComposerTests : BaseTest
    {
        YandexMessageComposerPage _page;

        IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = GetNewChromeDriver();
            _driver.Url = YandexLoginPage.url;
            YandexLoginPage loginPage = new YandexLoginPage(_driver);

            loginPage.LoginAs(AccountCredenitals.yandexLogin,
                              AccountCredenitals.yandexPassword)
                     .GoToMailboxPage();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Close();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Url = YandexMailboxPage.url;
            _page = (YandexMessageComposerPage)new YandexMailboxPage(_driver).OpenMessageComposer();
        }

        [Test]
        public void TempTest()
        {
            _page.SendMessage("SOME TOPIC", "HEY IM WRITING TO U", AccountCredenitals.mailruLogin + "@mail.ru");
        }
    }
}
