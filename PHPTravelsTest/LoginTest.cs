using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


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
            driver.Navigate().GoToUrl("http://www.phptravels.net/admin");

        }


        [Test]
        public void LoginFirstTime()
        {
            string username = "admin@phptravels.com";
            string password = "demoadmin";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);
            HomePage homePage = new HomePage(driver);

            try
            {
                homePage.VerifyWeAreHome();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            


        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
