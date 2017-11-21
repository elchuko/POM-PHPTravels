using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using PHPTravelsTest.POM;
using System.Threading;
using PHPTravelsTest.WebFactoryMethod;
using System.Configuration;

namespace PHPTravelsTest
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            WebFactory webFactory = new WebFactory();
            driver = webFactory.GetWebDriver(ConfigurationManager.AppSettings["browser"]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);

        }


        [Test]
        public void TC01_Login_AdminLoginSuccessfully()
        {
            
            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
            DashBoard dashBoard = new DashBoard(driver);
            System.Threading.Thread.Sleep(3000);
            
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
