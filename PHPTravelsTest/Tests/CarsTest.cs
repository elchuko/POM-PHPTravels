using System;
using System.Text;
using System.Collections.Generic;
using OpenQA.Selenium;
using NUnit;
using NUnit.Framework;
using PHPTravelsTest.POM;
using PHPTravelsTest.Validations;
using PHPTravelsTest.WebFactoryMethod;
using System.Configuration;
using PHPTravelsTest.Utils;

namespace PHPTravelsTest.Tests
{
    [TestFixture]
    public class CarsTest
    {
        private IWebDriver driver;
        private static readonly log4net.ILog Logger = Utils.Logger.GetLoggerInstance();


        [SetUp]
        public void SetUp()
        {
            //receives one driver as parameter and returns that 
            //parameter configured
            Logger.Info("Call to SetupClass.Setup(driver)");
            driver = SetUpClass.SetUp(driver);
            
            //login using the Username and Password in the App.config file
            LoginPage loginPage = new LoginPage(driver);
            Logger.Info("Call to FillLogin");
            loginPage.FillLogin(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

        }


        [Test]
        public void TC02_Cars_AddedCarsSuccessfully()
        {
            Logger.Info("Test Case Name TC02_Cars_AddedCarsSuccessfully");
            string carName = ConfigurationManager.AppSettings["carName"];

            //Execution
            DashBoard dashBoard = new DashBoard(driver);
            Logger.Info("Go to Cars Submenu");
            dashBoard.GoCarsSubMenu();
            CarsPage carsPage = new CarsPage(driver);
            Logger.Info("Add car by Name "+carName);
            carsPage.AddCar(carName);
            
            //validation
            Logger.Info("Validate Car created is the same");
            CarsValidations.ValidateAddedCar(carsPage,carName);
        }

        [TearDown]
        public void CleanUp()
        {
            CleanUpClass.CloseAndClean(driver);
        }
    }
}
