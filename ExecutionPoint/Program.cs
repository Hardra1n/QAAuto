using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Pages.Mailru;
using Pages.Yandex;
using System;
using System.Threading;

namespace ExecutionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            //MailruLoginTest();
            YandexLoginTest();
        }

        static void YandexLoginTest()
        {
            string username = "kirylkho123456";
            string password = "Qwerty1231";
            WebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 40);
            try
            {
                driver.Url = "https://passport.yandex.by/";
                Console.WriteLine(driver.Title);
                YandexLoginPage page = new YandexLoginPage(driver);
                page.TypeUsername(username);
                page.SubmitLoginWithoutSwitchToNewPage();
                page.TypePassword(password);
                //page.SubmitLogin();
                Thread.Sleep(10000);
                Console.WriteLine(driver.Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                driver.Close();
            }
        }

        static void MailruLoginTest()
        {

            string username = "khovan123456";
            string password = "tiSpaOUrN33&";
            WebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 40);
            try
            {
                driver.Url = "https://account.mail.ru/";
                Console.WriteLine(driver.Title);
                MailruLoginPage page = new MailruLoginPage(driver);
                page.TypeUsername(username);
                page.SubmitLoginWithoutSwitchToNewPage();
                page.TypePassword(password);
                page.SubmitLogin();
                Thread.Sleep(10000);
                Console.WriteLine(driver.Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                driver.Close();
            }
        }
    }
}
