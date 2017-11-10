using System;
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
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.phptravels.net/admin");
        }


        [TestMethod]
         public void CreateNewCouponwithMandatoryValues()
         {
             string username = "admin@phptravels.com";
             string password = "demoadmin";
             string percentage = "50.00";

             LoginPage loginPage = new LoginPage(driver);
             loginPage.FillLogin(username, password);

             DashBoard dashboard = new DashBoard(driver);
             dashboard.goToCouponsPage();

             CouponsPage coupons = new CouponsPage(driver);
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

            DashBoard dashboard = new DashBoard(driver);
            dashboard.goToCouponsPage();

            CouponsPage coupons = new CouponsPage(driver);
            coupons.DeleteCoupon();
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void UpdateMaxUsesFieldofFirstElement()
        {
            string username = "admin@phptravels.com";
            string password = "demoadmin";
            string MaxUses = "20";
            string Id = "10.00";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);

            DashBoard dashboard = new DashBoard(driver);
            dashboard.goToCouponsPage();

            CouponsPage coupons = new CouponsPage(driver);
            coupons.EditCoupon(MaxUses,Id);
            Thread.Sleep(1000);
            coupons.VerifyMaxUsesModification(MaxUses);

        }

        [TestMethod]
        public void SearchCoupon()
        {
            string username = "admin@phptravels.com";
            string password = "demoadmin";
            string Value = "10.00";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);

            DashBoard dashboard = new DashBoard(driver);
            dashboard.goToCouponsPage();

            CouponsPage coupons = new CouponsPage(driver);
            coupons.SearchAndVerifyCoupon(Value);
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
