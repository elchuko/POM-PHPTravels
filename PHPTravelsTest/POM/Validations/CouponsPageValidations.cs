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

            Assert.IsFalse(exists);
        }

        public static void ValidateCouponbyPercentage(IWebElement PercentageField,IWebElement NoFoundElementsField, string percentage)
        {
            string value1;

            Thread.Sleep(2000);

            if (NoFoundElementsField.Displayed == true)
            {
                value1 = NoFoundElementsField.Text;
            }
            else
            {
                value1 = PercentageField.Text;
            }
      
            Assert.IsTrue(value1 == percentage);
        }

        public static void ValidateCouponbyCouponCode(IWebElement CouponCodeField, IWebElement NoFoundElementsField, string percentage)
        {
            string value1;

            Thread.Sleep(2000);

            if (NoFoundElementsField.Displayed == true)
            {
                value1 = NoFoundElementsField.Text;
            }
            else
            {
                value1 = CouponCodeField.Text;
            }

            Assert.IsTrue(value1 == percentage);
        }

        public static void ValidateCouponByMaxUses(IWebElement MaxUsesField, IWebElement NoFoundElementsField, string MaxUses)
        {
            string values;

            Thread.Sleep(2000);

            if (NoFoundElementsField.Displayed == true)
            {
                values = NoFoundElementsField.Text;
            }
            else
            {
                values = MaxUsesField.Text;
            }

            Assert.IsTrue(values == MaxUses);
        }

        public static void ValidateSearchField(IWebElement CouponCodeField, IWebElement PercentageField, IWebElement MaxUsesField, IWebElement NoFoundElement, string value)
        {
            string comparison;
            if(CouponCodeField.Text == value)
            {
                comparison = CouponCodeField.Text;
            }
            else
            {
                if (PercentageField.Text == value)
                {
                    comparison = PercentageField.Text;
                }
                else
                    if (MaxUsesField.Text == value)
                {
                    comparison = MaxUsesField.Text;
                }
                else
                    comparison = NoFoundElement.Text;
            }
            Assert.IsTrue(comparison == value);
        }
    }
}
