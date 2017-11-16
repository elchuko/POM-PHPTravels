using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PHPTravelsTest.Utils;
using System;
using System.Threading;

namespace PHPTravelsTest.POM.Validations
{
    static class CouponsPageValidations
    {
        public static void ValidateDeletedCoupon(IWebDriver driver, string deletevalue)
        {
            //Initialize my CouponsPage POM
            CouponsPage CouponsPage = new CouponsPage(driver);

            //Initialize variables
            bool exists = false;

            Thread.Sleep(2000);
            if (ValidateIfNoElementsFoundExist(CouponsPage.NoFoundElementsField) == false)
            {
                exists = false;
            }
            else
            {
                exists = CouponsPage.CouponId.Displayed.Equals(deletevalue);
            }

            try
            {
                Assert.IsFalse(exists);
            }
            catch(Exception e)
            {
                Console.Write("Element was not Deleted successfully", e.Message);
            }
            
        }

        public static void ValidateCouponbyPercentage(IWebDriver driver, string percentage)
        {
            //Initialize my CouponsPage POM
            CouponsPage CouponsPage = new CouponsPage(driver);

            //Initialize variables
            string CouponPercentage = WebDriverUtils.GetElementText(CouponsPage.PercentageField);

            Thread.Sleep(2000);

            if (ValidateIfNoElementsFoundExist(CouponsPage.NoFoundElementsField) == true)
            {
                try
                {
                    Assert.IsTrue(CouponPercentage == percentage);
                }
                catch(Exception e)
                {
                    Console.Write("Percentage field is not displayed correctly., Message:{0}", e.Message);
                    throw;
                }
            }

            
        }

        public static void ValidateCouponbyCouponCode(IWebDriver driver, string CouponCode)
        {
            //Initialize my CouponsPage POM
            CouponsPage CouponsPage = new CouponsPage(driver);

            //Initialize variables
            string CouponCodeval = WebDriverUtils.GetElementText(CouponsPage.CouponCodeField);

            Thread.Sleep(2000);

            if (ValidateIfNoElementsFoundExist(CouponsPage.NoFoundElementsField) == true)
            {
                try
                {
                    Assert.IsTrue(CouponCodeval == CouponCode);
                }
                catch(Exception e)
                {
                    Console.Write("Coupon Code field is not displayed correctly., Message:{0}", e.Message);
                    throw;
                }
            }

            
        }

        public static void ValidateCouponByMaxUses(IWebDriver driver, string MaxUses)
        {
            //Initialize my CouponsPage POM
            CouponsPage CouponsPage = new CouponsPage(driver);

            //Initialize variables
            string CouponMaxUses = WebDriverUtils.GetElementText(CouponsPage.MaxUsesField);
            string values;

            Thread.Sleep(2000);

            if (ValidateIfNoElementsFoundExist(CouponsPage.NoFoundElementsField) == true)
            {
                values = CouponMaxUses;
                try
                {
                    Assert.IsTrue(values == MaxUses);
                }
                catch (Exception e)
                {
                    Console.Write("Max Uses field is not displayed correctly., Message:{0}", e.Message);
                    throw;
                }
            }

            
        }

        public static void ValidateSearchField(IWebDriver driver, string value)
        {   //Initialize my CouponsPage POM
            CouponsPage CouponsPage = new CouponsPage(driver);

            //Initialize variables
            bool failed = false;
            string CouponCode = WebDriverUtils.GetElementText(CouponsPage.CouponCodeField);
            string CouponPercentage = WebDriverUtils.GetElementText(CouponsPage.PercentageField);
            string CouponMaxUses = WebDriverUtils.GetElementText(CouponsPage.MaxUsesField);

            if (ValidateIfNoElementsFoundExist(CouponsPage.NoFoundElementsField) == true)
            {
                if (CouponCode == value)
                {
                    failed = true;
                }
                else
                {
                    Thread.Sleep(3000);
                    if (CouponPercentage == value)
                    {
                        failed = true;
                    }
                    else
                    {
                        if (CouponMaxUses == value)
                        {
                            failed = true;
                        }
                        else
                            failed = false;
                    }

                }
            }
           else
            {
                failed = false;
            }

            try
            {
                Assert.IsTrue(failed);
            }
            catch(Exception e)
            {
                Console.Write("No elements were found for the given value to serch., Message:{0}",e.Message);
                throw;
            }
        }

        public static bool ValidateIfNoElementsFoundExist(IWebElement NoFoundElementsField)
        {
            //Initializa variables
            bool failed = false;

            try
            {
                if (NoFoundElementsField.Displayed == true)
                {
                    failed = false;
                }
            }
            catch (Exception)
            {
                failed = true;
            }

            return failed;
        }

        public static void ValidateIfURLIsCorrect(IWebDriver driver, string url)
        {
            try
            {
                Assert.IsTrue(driver.Url.Contains(url));
            }
            catch(Exception e)
            {
                Console.Write("URL is not correct. Message: {0}", e.Message);
            }
        }
    }
}
