using ModelNService.Driver;
using ModelNService.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Pages.Yandex;
using System.Threading;

namespace Tests.Yandex
{
    [TestFixture]
    [Category("All")]
    public class YandexMailboxTests : BaseTest
    {
        private YandexMailboxPage _page;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = DriverManager.GetWebDriver();
            _driver.Url = YandexLoginPage.URL;
            _page = (YandexMailboxPage)new YandexLoginPage(_driver).LoginAs(accounts.Yandex)
                                                                   .GoToMailboxPage();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DriverManager.CloseDriver();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Url = YandexMailboxPage.URL;
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
            
            string actualNickname = homepage.ChangeNickname(changingNickname)
                                            .GetNickname();

            Assert.AreEqual(changingNickname, actualNickname);

            homepage.ChangeNickname(primaryNickname);
        }
    }
}
