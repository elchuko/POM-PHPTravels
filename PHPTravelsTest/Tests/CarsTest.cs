using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit;
using NUnit.Framework;
using PHPTravelsTest.POM;
using PHPTravelsTest.WebFactoryMethod;

namespace PHPTravelsTest.Tests
{
    [TestClass]
    public class CarsTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            WebFactory webFactory = new WebFactory();
            driver = webFactory.GetWebDriver(Browsers.Chrome.ToString());
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.phptravels.net/admin");

        }


        [Test]
        public void AddCarTest()
        {
            string username = "admin@phptravels.com";
            string password = "demoadmin";
            string carName = "Ferrari";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);
            DashBoard dashBoard = new DashBoard(driver);
            dashBoard.GoCarsSubMenu();
            CarsPage carsPage = new CarsPage(driver);
            carsPage.AddCar(carName);

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
