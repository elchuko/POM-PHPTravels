using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PHPTravelsTest.POM.Validations
{
    class CouponsPageValidations
    {
        private CouponsPageValidations()
        {

        }

        public static void ValidateDeletedCoupon(IWebElement NoFoundElementsField, IWebElement CouponId, string deletevalue)
        {
            bool exists = false;

            Thread.Sleep(2000);
            if (NoFoundElementsField.Displayed == true)
            {
                exists = false;
            }
            else
            {
                exists = CouponId.Displayed.Equals(deletevalue);
            }

            try
            {
                Assert.IsFalse(exists);
            }
            catch(Exception e)
            {
                Console.Write("Element was not Delete successfully", e.Message);
            }
            
        }

        public static void ValidateCouponbyPercentage(IWebElement PercentageField, IWebElement NoFoundElementsField, string percentage)
        {
            string value1;

            Thread.Sleep(2000);

            if (ValidateNoElementsFound(NoFoundElementsField) == true)
            {
                value1 = PercentageField.Text;

                try
                {
                    Assert.IsTrue(value1 == percentage);
                }
                catch(Exception e)
                {
                    Console.Write("Percentage field is not displayed correctly.., Message:{0}", e.Message);
                    throw;
                }
            }

            
        }

        public static void ValidateCouponbyCouponCode(IWebElement CouponCodeField, IWebElement NoFoundElementsField, string CouponCode)
        {
            string value1;

            Thread.Sleep(2000);

            if (ValidateNoElementsFound(NoFoundElementsField) == true)
            {
                value1 = CouponCodeField.Text;

                try
                {
                    Assert.IsTrue(value1 == CouponCode);
                }
                catch(Exception e)
                {
                    Console.Write("Coupon Code field is not displayed correctly.., Message:{0}", e.Message);
                    throw;
                }
            }

            
        }

        public static void ValidateCouponByMaxUses(IWebElement MaxUsesField, IWebElement NoFoundElementsField, string MaxUses)
        {
            string values;

            Thread.Sleep(2000);

            if (ValidateNoElementsFound(NoFoundElementsField) == true)
            {
                values = MaxUsesField.Text;
                try
                {
                    Assert.IsTrue(values == MaxUses);
                }
                catch (Exception e)
                {
                    Console.Write("Max Uses field is not displayed correctly.., Message:{0}", e.Message);
                    throw;
                }
            }

            
        }

        public static void ValidateSearchField(IWebElement CouponCodeField, IWebElement PercentageField, IWebElement MaxUsesField, IWebElement NoFoundElement, string value)
        {
            bool failed = ValidateNoElementsFound(NoFoundElement);

           if(failed==true)
            {
                if (CouponCodeField.Text == value)
                {
                    failed = true;
                }
                else
                {
                    if (PercentageField.Text == value)
                    {
                        failed = true;
                    }
                    else
                    {
                        if (MaxUsesField.Text == value)
                        {
                            failed = true;
                        }
                        else
                            failed = false;
                    }

                }
            }

            try
            {
                Assert.IsTrue(failed);
            }
            catch(Exception e)
            {
                Console.Write("No Elements compatible were found.., Message:{0}",e.Message);
                throw;
            }
        }

        public static bool ValidateNoElementsFound(IWebElement NoFoundElement)
        {
            bool failed = false;

            try
            {
                if (NoFoundElement.Enabled == true)
                {
                    failed = false;
                }
            }
            catch (FieldAccessException)
            {
                failed = true;
            }

            return failed;
        }
    }
}
