using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PHPTravelsTest.POM;
using System.Threading;
using PHPTravelsTest.WebFactoryMethod;
using PHPTravelsTest.POM.Validations;
using System.Configuration;
using NUnit.Framework;
using PHPTravelsTest.Utils;

namespace PHPTravelsTest
{
    /// <summary>
    /// Validation of Coupons test cases
    /// </summary>
    [TestFixture]
    public class CouponsTest
    {
        private IWebDriver driver;
        private static readonly log4net.ILog Logger = Utils.Logger.GetLoggerInstance();

        [SetUp]
        public void SetUp()
        {
            Logger.Info("Call to SetupClass.Setup(driver)");
            driver = SetUpClass.SetUp(driver);

            LoginPage loginPage = new LoginPage(driver);
            Logger.Info("Call to FillLogin");
            loginPage.FillLogin(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
        }


        [Test]
         public void TC27_Coupons_AddedCouponSuccessfully()
         {
            Logger.Info("Test Case Name TC27_Coupons_AddedCouponSuccessfully");
             string percentage = ConfigurationManager.AppSettings["percentage"];
             
             //Execution
             DashBoard dashboard = new DashBoard(driver);
             Logger.Info("Go to CouponsPage");
             CouponsPage coupons = dashboard.goToCouponsPage();
             string CodeValue = coupons.AddCouponWithGenericCode(percentage);
             coupons.SearchCoupon(CodeValue);

             //Validation
             CouponsPageValidations.ValidateCouponbyPercentage(coupons, driver, percentage);

             Thread.Sleep(1000);
         }

        [Test]
        public void TC28_Coupons_RemovedCouponSuccessfully()
        {
            Logger.Info("Test Case Name TC28_Coupons_RemovedCouponSuccessfully");
            string valuetodelete = ConfigurationManager.AppSettings["percentage"];

            //Execution
            DashBoard dashboard = new DashBoard(driver);
            CouponsPage coupons = dashboard.goToCouponsPage();
            Logger.Info("SearchCoupon " + valuetodelete);
            coupons.SearchCoupon(valuetodelete);
            CouponsPageValidations.ValidateSearchField(coupons, driver, valuetodelete);
            Logger.Info("Delecte Coupon "+ valuetodelete);
            coupons.DeleteCoupon(valuetodelete);

            //Validation
            CouponsPageValidations.ValidateDeletedCoupon(coupons, driver,valuetodelete);

            Thread.Sleep(1000);
        }

        [Test]
        public void TC30_Coupons_EditedCouponSuccessfully()
        {
            Logger.Info("test Case name TC_30_Coupons_EditedCouponSuccessfully");
            string MaxUses = ConfigurationManager.AppSettings["MaxUses"];
            string Id = ConfigurationManager.AppSettings["id"];

            //Execution
            DashBoard dashboard = new DashBoard(driver);
            CouponsPage coupons = dashboard.goToCouponsPage();
            Logger.Info("SearchCoupon "+Id);
            coupons.SearchCoupon(Id);
            CouponsPageValidations.ValidateSearchField(coupons, driver,Id);
            Logger.Info("EditCouponOnMaxUseValue "+MaxUses);
            coupons.EditCouponOnMaxUseValue(MaxUses);
            Logger.Info("SearchCoupon " +Id);
            coupons.SearchCoupon(Id);

            //Validation
            CouponsPageValidations.ValidateCouponByMaxUses(coupons, driver, MaxUses);
            Thread.Sleep(1000);

        }

        [Test]
        public void TC31_Coupon_SearchedCouponSuccessfully()
        {
            Logger.Info("test Case name TC31_Coupon_SearchedCouponSuccessfully");
            string Value = ConfigurationManager.AppSettings["number"];

            //Execution
            DashBoard dashboard = new DashBoard(driver);
            CouponsPage coupons = dashboard.goToCouponsPage();
            Logger.Info("SearchCoupon "+Value);
            coupons.SearchCoupon(Value);

            //Validation
            Logger.Info("ValidateSearchField");
            CouponsPageValidations.ValidateSearchField(coupons, driver, Value);
            Thread.Sleep(1000);
        }

        [Test]
        public void TC32_Coupon_PrintedCouponSuccessfully()
        {
            Logger.Info("Test Case Name TC32_Coupon_PrintedCouponSuccessfully");
            string ParentWindow;
            string printpage = ConfigurationManager.AppSettings["printpage"];
            string mainpage = ConfigurationManager.AppSettings["mainpage"];

            //Execution
            DashBoard dashboard = new DashBoard(driver);
            CouponsPage coupons = dashboard.goToCouponsPage();
            Logger.Info("OpenPrintWindow");
            ParentWindow = coupons.OpenPrintWindow();

            //Validation
            Logger.Info("ValidateifURLisCorrect " + printpage);
            CouponsPageValidations.ValidateIfURLIsCorrect(driver, printpage);
            Logger.Info("ClosePrintWindow");
            coupons.ClosePrintWindow(ParentWindow);
            CouponsPageValidations.ValidateIfURLIsCorrect(driver, mainpage);
            Thread.Sleep(1000);
        }

        [TearDown]
        public void CleanUp()
        {
            CleanUpClass.CloseAndClean(driver);
        }
    }
}
