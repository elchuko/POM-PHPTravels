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
        string username = "admin@phptravels.com";
        string password = "demoadmin";

        [TestInitialize]
        public void SetUp()
        {
            WebFactory webFactory = new WebFactory();
            driver = webFactory.GetWebDriver(Browsers.Chrome.ToString());
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.phptravels.net/admin");
            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);
        }


        [TestMethod]
         public void TC27_Coupons_AddedCouponSuccessfully()
         {
             string percentage = "50.00";

             DashBoard dashboard = new DashBoard(driver);
             dashboard.goToCouponsPage();

             CouponsPage coupons = dashboard.goToCouponsPage();

             string CodeValue = coupons.AddCouponWithGenericCode(percentage);
             coupons.SearchCoupon(CodeValue);
             CouponsPageValidations.ValidateCouponbyPercentage(coupons, driver, percentage);

             Thread.Sleep(1000);
         }

        [TestMethod]
        public void TC28_Coupons_RemovedCouponSuccessfully()
        {
            string valuetodelete = "50.00";

            DashBoard dashboard = new DashBoard(driver);
            CouponsPage coupons = dashboard.goToCouponsPage();

            coupons.SearchCoupon(valuetodelete);
            CouponsPageValidations.ValidateSearchField(coupons, driver, valuetodelete);

            coupons.DeleteCoupon(valuetodelete);
            CouponsPageValidations.ValidateDeletedCoupon(coupons, driver,valuetodelete);

            Thread.Sleep(1000);
        }

        [TestMethod]
        public void TC30_Coupons_EditedCouponSuccessfully()
        {
            string MaxUses = "20";
            string Id = "wWIw";

            DashBoard dashboard = new DashBoard(driver);
            CouponsPage coupons = dashboard.goToCouponsPage();

            coupons.SearchCoupon(Id);
            CouponsPageValidations.ValidateSearchField(coupons, driver,Id);

            coupons.EditCouponOnMaxUseValue(MaxUses);

            coupons.SearchCoupon(Id);
            CouponsPageValidations.ValidateCouponByMaxUses(coupons, driver, MaxUses);
            Thread.Sleep(1000);

        }

        [TestMethod]
        public void TC31_Coupon_SearchedCouponSuccessfully()
        {
            string Value = "10.00";

            DashBoard dashboard = new DashBoard(driver);
            CouponsPage coupons = dashboard.goToCouponsPage();

            coupons.SearchCoupon(Value);
            CouponsPageValidations.ValidateSearchField(coupons, driver, Value);
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void TC32_Coupon_PrintedCouponSuccessfully()
        {
            string ParentWindow;
            string printpage = "xcrud";
            string mainpage = "coupons";

            DashBoard dashboard = new DashBoard(driver);
            CouponsPage coupons = dashboard.goToCouponsPage();

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
