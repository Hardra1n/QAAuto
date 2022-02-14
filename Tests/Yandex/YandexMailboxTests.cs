using ModelNService.Driver;
using ModelNService.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Pages.Yandex;
using System;
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

        [TearDown]
        public void TearDown()
        {
            HandleTestFailure();
        }

        [Test]
        public void CanOpenMessageComposerTest()
        {
            try
            {
                YandexMessageComposerPage composerPage = (YandexMessageComposerPage)_page.OpenMessageComposer();
                composerPage.EnterRecipientEmailSendingMessage("temp@temp");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message + '\n' + ex.StackTrace);
            }
        }

        [Test]
        public void CanChangeNickname()
        {
            try
            {
                string changingNickname = "Lola";
                IHomePage homepage = _page.GoToHomePage();
                string primaryNickname = homepage.GetNickname();

                string actualNickname = homepage.ChangeNickname(changingNickname)
                                                .GetNickname();

                Assert.AreEqual(changingNickname, actualNickname);

                homepage.ChangeNickname(primaryNickname);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message + '\n' + ex.StackTrace);
            }
        }
    }
}
