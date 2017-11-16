using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PHPTravelsTest.POM;
using System.Threading;
using PHPTravelsTest.WebFactoryMethod;
using PHPTravelsTest.POM.Validations;

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
         public void TC27_Coupons_AddedCouponSuccessfully()
         {
             string username = "admin@phptravels.com";
             string password = "demoadmin";
             string percentage = "50.00";

             LoginPage loginPage = new LoginPage(driver);
             loginPage.FillLogin(username, password);

             DashBoard dashboard = new DashBoard(driver);
             dashboard.goToCouponsPage();

             CouponsPage coupons = new CouponsPage(driver);

             coupons.AddCouponWithGenericCode(percentage);
             CouponsPageValidations.ValidateCouponbyPercentage(driver, percentage);

             Thread.Sleep(1000);
         }

        [TestMethod]
        public void TC28_Coupons_RemovedCouponSuccessfully()
        {
            string username = "admin@phptravels.com";
            string password = "demoadmin";
            string valuetodelete = "50.00";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);

            DashBoard dashboard = new DashBoard(driver);
            dashboard.goToCouponsPage();

            CouponsPage coupons = new CouponsPage(driver);

            coupons.SearchCoupon(valuetodelete);
            CouponsPageValidations.ValidateSearchField(driver,valuetodelete);

            coupons.DeleteCoupon(valuetodelete);
            CouponsPageValidations.ValidateDeletedCoupon(driver,valuetodelete);

            Thread.Sleep(1000);
        }

        [TestMethod]
        public void TC30_Coupons_EditedCouponSuccessfully()
        {
            string username = "admin@phptravels.com";
            string password = "demoadmin";
            string MaxUses = "20";
            string Id = "wWIw";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);

            DashBoard dashboard = new DashBoard(driver);
            dashboard.goToCouponsPage();

            CouponsPage coupons = new CouponsPage(driver);

            coupons.SearchCoupon(Id);
            CouponsPageValidations.ValidateSearchField(driver,Id);

            coupons.EditCouponOnMaxUseValue(MaxUses);

            coupons.SearchCoupon(Id);
            CouponsPageValidations.ValidateCouponByMaxUses(driver,MaxUses);
            Thread.Sleep(1000);

        }

        [TestMethod]
        public void TC31_Coupon_SearchedCouponSuccessfully()
        {
            string username = "admin@phptravels.com";
            string password = "demoadmin";
            string Value = "10.00";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);

            DashBoard dashboard = new DashBoard(driver);
            dashboard.goToCouponsPage();

            CouponsPage coupons = new CouponsPage(driver);
            coupons.SearchCoupon(Value);
            CouponsPageValidations.ValidateSearchField(driver,Value);
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void TC32_Coupon_PrintedCouponSuccessfully()
        {
            string username = "admin@phptravels.com";
            string password = "demoadmin";
            string ParentWindow;
            string printpage = "xcrud";
            string mainpage = "coupons";

            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);

            DashBoard dashboard = new DashBoard(driver);
            dashboard.goToCouponsPage();

            CouponsPage coupons = new CouponsPage(driver);

            ParentWindow = coupons.OpenPrintWindow();
            CouponsPageValidations.ValidateIfURLIsCorrect(driver, printpage);

            coupons.ClosePrintWindow(ParentWindow);
            CouponsPageValidations.ValidateIfURLIsCorrect(driver, mainpage);
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
