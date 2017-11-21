using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PHPTravelsTest.WebFactoryMethod;

namespace PHPTravelsTest.POM
{
    public static class SetUpClass
    {
        private static readonly log4net.ILog Logger = Utils.Logger.GetLoggerInstance();
        public static IWebDriver SetUp(IWebDriver driver)
        {
            Logger.Info("inside SetupClass.Setup(driver)");
            //Factory Method which gets the browser from the App.config file
            Logger.Info("Creation of webFactory Object");
            WebFactory webFactory = new WebFactory();
            Logger.Info("Configuring driver to work with browser: " + ConfigurationManager.AppSettings["browser"]);
            driver = webFactory.GetWebDriver(ConfigurationManager.AppSettings["browser"]);
            Logger.Info("Driver returned: "+ driver);

            //Opens the driver and goes to the URL specified in the App.config file
            driver.Manage().Window.Maximize();
            Logger.Info("Go to URL "+ ConfigurationManager.AppSettings["URL"]);
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            return driver;
        }
    }
}
