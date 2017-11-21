using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PHPTravelsTest.Utils;
using System;
using System.Threading;

namespace PHPTravelsTest.POM.Validations
{
    public static class CouponsPageValidations
    {
        public static void ValidateDeletedCoupon(CouponsPage CouponsPage,IWebDriver driver,string deletevalue)
        {

            //Initialize variables
            bool exists = false;

            WebDriverUtils.WaitForElementToBeVisible(driver, CouponsPage.TableFrameXpath);

            if (ValidateIfNoElementsFoundExist(driver, CouponsPage.NoFoundElementsField) == false)
            {
                exists = false;
            }
            else
            {
                WebDriverUtils.WaitForElementToBeClickable(driver, CouponsPage.CouponId);
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

        public static void ValidateCouponbyPercentage(CouponsPage CouponsPage,IWebDriver driver, string percentage)
        {

            WebDriverUtils.WaitForElementToBeVisible(driver, CouponsPage.TableFrameXpath);

            if (ValidateIfNoElementsFoundExist(driver, CouponsPage.NoFoundElementsField) == true)
            {
                //Initialize variables
                WebDriverUtils.WaitForElementToBeClickable(driver, CouponsPage.PercentageField);
                string CouponPercentage = WebDriverUtils.GetElementText(CouponsPage.PercentageField);

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

        public static void ValidateCouponbyCouponCode(CouponsPage CouponsPage, IWebDriver driver, string CouponCode)
        {

            WebDriverUtils.WaitForElementToBeVisible(driver, CouponsPage.TableFrameXpath);

            if (ValidateIfNoElementsFoundExist(driver, CouponsPage.NoFoundElementsField) == true)
            {
                //Initialize variables
                WebDriverUtils.WaitForElementToBeClickable(driver, CouponsPage.CouponCodeField);
                string CouponCodeval = WebDriverUtils.GetElementText(CouponsPage.CouponCodeField);

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

        public static void ValidateCouponByMaxUses(CouponsPage CouponsPage, IWebDriver driver, string MaxUses)
        {

            //Initialize variables
            WebDriverUtils.WaitForElementToBeVisible(driver, CouponsPage.TableFrameXpath);

            if (ValidateIfNoElementsFoundExist(driver, CouponsPage.NoFoundElementsField) == true)
            {
                WebDriverUtils.WaitForElementToBeClickable(driver, CouponsPage.MaxUsesField);
                string CouponMaxUses = WebDriverUtils.GetElementText(CouponsPage.MaxUsesField);

                try
                {
                    Assert.IsTrue(CouponMaxUses == MaxUses);
                }
                catch (Exception e)
                {
                    Console.Write("Max Uses field is not displayed correctly., Message:{0}", e.Message);
                    throw;
                }
            }

            
        }

        public static void ValidateSearchField(CouponsPage CouponsPage, IWebDriver driver, string value)
        {   

            //Initialize variables
            bool failed = false;

            WebDriverUtils.WaitForElementToBeVisible(driver,CouponsPage.TableFrameXpath);

            if (ValidateIfNoElementsFoundExist(driver,CouponsPage.NoFoundElementsField) == true)
            {
                WebDriverUtils.WaitForElementToBeClickable(driver, CouponsPage.CouponCodeField);

                string CouponCode = WebDriverUtils.GetElementText(CouponsPage.CouponCodeField);
                string CouponPercentage = WebDriverUtils.GetElementText(CouponsPage.PercentageField);
                string CouponMaxUses = WebDriverUtils.GetElementText(CouponsPage.MaxUsesField);

                if (CouponCode == value)
                {
                    failed = true;
                }
                else
                {
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
                Console.Write("No elements were found for the given value to search., Message:{0}",e.Message);
                throw;
            }
        }

        public static bool ValidateIfNoElementsFoundExist(IWebDriver driver, IWebElement NoFoundElementsField)
        {
            //Initialize variables
            bool failed = false;

            try
            {
                WebDriverUtils.WaitForNoFoundElementToBeClickable(driver, NoFoundElementsField);
                failed = false;
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
