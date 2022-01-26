using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Pages.Yandex;
using System.Threading;

namespace Tests.Yandex
{
    [TestFixture]
    public class YandexMailboxTests
    {
        YandexMailboxPage _page;

        IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = Driver.GetChromeDriver();
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

        [Test]
        public void CanChangeNickname()
        {
            string changingNickname = "Lola";
            IHomePage homepage = _page.GoToHomePage();
            string primaryNickname = homepage.GetNickname();
            
            homepage.ChangeNickname(changingNickname);
            string actualNickname = homepage.GetNickname();
            homepage.ChangeNickname(primaryNickname);

            Assert.AreEqual(changingNickname, actualNickname);
        }
    }
}
