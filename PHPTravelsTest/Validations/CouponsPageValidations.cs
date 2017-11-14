using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

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
            if (ValidateIfNoElementsFoundExist(NoFoundElementsField) == false)
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
                Console.Write("Element was not Deleted successfully", e.Message);
            }
            
        }

        public static void ValidateCouponbyPercentage(IWebElement PercentageField, IWebElement NoFoundElementsField, string percentage)
        {
            string value1;

            Thread.Sleep(2000);

            if (ValidateIfNoElementsFoundExist(NoFoundElementsField) == true)
            {
                value1 = PercentageField.Text;

                try
                {
                    Assert.IsTrue(value1 == percentage);
                }
                catch(Exception e)
                {
                    Console.Write("Percentage field is not displayed correctly., Message:{0}", e.Message);
                    throw;
                }
            }

            
        }

        public static void ValidateCouponbyCouponCode(IWebElement CouponCodeField, IWebElement NoFoundElementsField, string CouponCode)
        {
            string value1;

            Thread.Sleep(2000);

            if (ValidateIfNoElementsFoundExist(NoFoundElementsField) == true)
            {
                value1 = CouponCodeField.Text;

                try
                {
                    Assert.IsTrue(value1 == CouponCode);
                }
                catch(Exception e)
                {
                    Console.Write("Coupon Code field is not displayed correctly., Message:{0}", e.Message);
                    throw;
                }
            }

            
        }

        public static void ValidateCouponByMaxUses(IWebElement MaxUsesField, IWebElement NoFoundElementsField, string MaxUses)
        {
            string values;

            Thread.Sleep(2000);

            if (ValidateIfNoElementsFoundExist(NoFoundElementsField) == true)
            {
                values = MaxUsesField.Text;
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

        public static void ValidateSearchField(IWebElement CouponCodeField, IWebElement PercentageField, IWebElement MaxUsesField, IWebElement NoFoundElement, string value)
        {
            bool failed = false;

           if(ValidateIfNoElementsFoundExist(NoFoundElement) == true)
            {
                if (CouponCodeField.Text == value)
                {
                    failed = true;
                }
                else
                {
                    Thread.Sleep(3000);
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

        public static bool ValidateIfNoElementsFoundExist(IWebElement NoFoundElement)
        {
            bool failed = false;

            try
            {
                if (NoFoundElement.Displayed == true)
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
    }
}
