using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PHPTravelsTest.Utils;
using System;
using System.Threading;
using log4net.Core;

namespace PHPTravelsTest.POM.Validations
{
    public static class CouponsPageValidations
    {
        private static readonly log4net.ILog Logger = Utils.Logger.GetLoggerInstance();
        public static void ValidateDeletedCoupon(CouponsPage CouponsPage,IWebDriver driver,string deletevalue)
        {
            try
            {
                Logger.Info("Try to Assert if the coupon doesn't exist");
                Assert.IsFalse(CouponsPage.CouponDeletedMethod(deletevalue));
            }
            catch(Exception e)
            {
                Logger.Error("The Coupon still exists");
                Console.Write("Element was not Deleted successfully", e.Message);
                Assert.Fail();
            }
        }

        public static void ValidateCouponbyPercentage(CouponsPage CouponsPage,IWebDriver driver, string percentage)
        {
                try
                {
                    Logger.Info("Assert if CouponPercentage == percentage");
                    Assert.AreEqual(percentage, CouponsPage.CouponPercentageMethod());
                }
                catch(Exception e)
                {
                    Logger.Error("They are not Equal");
                    Console.Write("Percentage field is not displayed correctly., Message:{0}", e.Message);
                    Assert.Fail();
                }

            
        }

        public static void ValidateCouponbyCouponCode(CouponsPage CouponsPage, IWebDriver driver, string CouponCode)
        {
            Logger.Info("Inside ValidateCouponbyCouponCode");
           
                try
                {
                    Logger.Info("Try to Assert if CouponCodeval == CouponCode");
                    Assert.AreEqual(CouponCode,CouponsPage.CouponCodeMethod());
                }
                catch(Exception e)
                {
                    Logger.Error("They are not the same");
                    Console.Write("Coupon Code field is not displayed correctly., Message:{0}", e.Message);
                    Assert.Fail();
                }
            
        }

        public static void ValidateCouponByMaxUses(CouponsPage CouponsPage, IWebDriver driver, string MaxUses)
        {
            Logger.Info("Inside ValidateCouponByMaxUses");
                try
                {
                    Logger.Info("Try to Assert if CouponMaxUses == MaxUses");
                    Assert.AreEqual(MaxUses,CouponsPage.MaxUsesMethod());
                }
                catch (Exception e)
                {
                    Logger.Error("They are not equal");
                    Console.Write("Max Uses field is not displayed correctly., Message:{0}", e.Message);
                    Assert.Fail();
                }
        }

        public static void ValidateSearchField(CouponsPage CouponsPage, IWebDriver driver, string value)
        {   
            Logger.Info("inside ValidateSearchField");
            try
            {
                Logger.Info("Try to Assert if search didn't fail");
                Assert.IsTrue(CouponsPage.SearchFieldMethod(value));
            }
            catch(Exception e)
            {
                Logger.Error("There was no field with that value");
                Console.Write("No elements were found for the given value to search., Message:{0}",e.Message);
                Assert.Fail();
            }
        }

        public static bool ValidateIfNoElementsFoundExist(IWebDriver driver, IWebElement NoFoundElementsField)
        {
            Logger.Info("Inside ValidateIfNoElementsFoundExist");
            //Initialize variables
            bool failed = false;

            try
            {
                Logger.Info("Waits until element is visible");
                WebDriverUtils.WaitForNoFoundElementToBeClickable(driver, NoFoundElementsField);
                failed = false;
            }
            catch (Exception)
            {
                Logger.Error("It is not visible");
                failed = true;
                //Assert.Fail();

            }

            return failed;
        }

        public static void ValidateIfURLIsCorrect(IWebDriver driver, string url)
        {
            try
            {
                Logger.Info("Assert if we are in the correct URL");
                Assert.IsTrue(driver.Url.Contains(url));
            }
            catch(Exception e)
            {
                Logger.Error("URL is not correct");
                Console.Write("URL is not correct. Message: {0}", e.Message);
                Assert.Fail();

            }
        }
    }
}
