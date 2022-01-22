using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Yandex;

namespace Tests.Yandex
{
    [TestFixture]
    public class YandexMailboxTests : BaseTest
    {
        YandexMailboxPage _page;

        IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = GetNewChromeDriver();
            _driver.Url = YandexLoginPage.url;
            YandexLoginPage loginPage = new YandexLoginPage(_driver);

            _page = (YandexMailboxPage)loginPage.LoginAs(AccountCredenitals.yandexLogin,
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
        }

        [Test]
        public void CanOpenMessageComposerTest()
        {
            YandexMessageComposerPage composerPage = (YandexMessageComposerPage)_page.OpenMessageComposer();
            try
            {
                composerPage.EnterRecipientEmailSendingMessage("temp@temp");
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
