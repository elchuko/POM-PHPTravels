using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace PHPTravelsTest
{
    [TestClass]
    public class MyProfileTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            // driver = new FirefoxDriver(new FirefoxOptions()); //factory for chosing which browser is needed
            driver = new ChromeDriver(new ChromeOptions());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("http://www.phptravels.net/admin");
        }


        [Test]
        public void MyProfileTestCase()
        {
            string username = "admin@phptravels.com";
            string password = "demoadmin";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);
            DashBoard dashBoard = new DashBoard(driver);
            dashBoard.goMyProfile();
            MyProfilePage myProfile = new MyProfilePage(driver);
            System.Threading.Thread.Sleep(3000);
            myProfile.MethodForTestCase("Eusebio");
            System.Threading.Thread.Sleep(3000);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}

