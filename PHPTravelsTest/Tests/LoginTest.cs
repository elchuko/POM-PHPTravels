using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using PHPTravelsTest.POM;
using System.Threading;
using PHPTravelsTest.WebFactoryMethod;
using System.Configuration;
using PHPTravelsTest.Utils;

namespace PHPTravelsTest
{
    [TestFixture]
    public class LoginTest
    {
        private IWebDriver driver;

        private static readonly log4net.ILog Logger = Utils.Logger.GetLoggerInstance();

        [SetUp]
        public void SetUp()
        {
            //SetUp method that recieves a driver as a parameter and returns 
            //that same driver configured
            Logger.Info("Call to SetUpClass.SetUp(driver)");
            driver = SetUpClass.SetUp(driver);
          
        }


        [Test]
        public void TC01_Login_AdminLoginSuccessfully()
        {
            Logger.Info("TestCase Name TC01_Login_AdminLoginSuccessfully");
            LoginPage loginPage = new LoginPage(driver);
            Logger.Info("Call to LoginPage.FillLogin(username,password)");
            loginPage.FillLogin(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
            DashBoard dashBoard = new DashBoard(driver);
            System.Threading.Thread.Sleep(3000);
            
        }

        [TearDown]
        public void CleanUp()
        {
            CleanUpClass.CloseAndClean(driver);
        }
    }
}
