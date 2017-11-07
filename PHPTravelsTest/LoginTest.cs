using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace PHPTravelsTest
{
    [TestClass]
    public class LoginTest
    {
        private ChromeDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(new ChromeOptions()); //factory for chosing which driver is needed
            
        }


        [Test]
        public void LoginFirstTime()
        {

            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.fillLogin();
            homePage.


        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
