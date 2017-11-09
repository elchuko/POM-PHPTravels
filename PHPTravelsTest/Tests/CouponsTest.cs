﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PHPTravelsTest.POM;
using System.Threading;
using PHPTravelsTest.WebFactoryMethod;

namespace PHPTravelsTest
{
    /// <summary>
    /// Validation of Coupons test cases
    /// </summary>
    [TestClass]
    public class CouponsTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            WebFactory webFactory = new WebFactory();
            driver = webFactory.GetWebDriver(Browsers.Chrome.ToString());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.phptravels.net/admin/coupons");
        }


        [TestMethod]
         public void CreateNewCouponwithMandatoryValues()
         {
             string username = "admin@phptravels.com";
             string password = "demoadmin";
             string percentage = "50";

             LoginPage loginPage = new LoginPage(driver);
             loginPage.FillLogin(username, password);

             Coupons coupons = new Coupons(driver);
             coupons.WaitforCouponsPage();
             coupons.AddCoupon(percentage);
             Thread.Sleep(1000);
         }

        [TestMethod]
        public void DeletetheFirstCouponAvailable()
        {
            string username = "admin@phptravels.com";
            string password = "demoadmin";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);

            Coupons coupons = new Coupons(driver);
            coupons.WaitforCouponsPage();
            coupons.DeleteCoupon();
            Thread.Sleep(1000);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
