using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using PHPTravelsTest.POM;
using System.Threading;

namespace PHPTravelsTest
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
           // driver = new FirefoxDriver(new FirefoxOptions()); //factory for chosing which browser is needed
            driver = new ChromeDriver(new ChromeOptions());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.phptravels.net/admin");
        }


        [Test]
        public void LoginFirstTime()
        {
            string username = "admin@phptravels.com";
            string password = "demoadmin";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);
            DashBoard dashBoard = new DashBoard(driver);
            System.Threading.Thread.Sleep(3000);

            //try
            //{
            //    dashBoard.VerifyWeAreDashBoard();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
