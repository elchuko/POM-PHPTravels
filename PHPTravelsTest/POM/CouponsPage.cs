﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PHPTravelsTest.POM
{
    class CouponsPage : BasicPage
    {

        //Initialize WebDriver(s)
        public IWebDriver driver;
        private WebDriverWait wait;

        //Initialize xpaths variables
        [FindsBy(How = How.XPath, Using = "//div[@id='content']/div[1]/div[2]/div[1]/button")]
        private IWebElement AddButton;

       /* [FindsBy(How = How.XPath, Using = "//div[@id='editCop11']/div[2]/div[1]/div[4]/button[@id=11]")]
        private IWebElement EditButton;*/

        [FindsBy(How = How.XPath, Using = "//div[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[3]/a")]
        private IWebElement SearchButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[11]/span/a[3]/i")]
        private IWebElement DeleteButton;

        [FindsBy(How = How.Id, Using = "rate")]
        private IWebElement percentageField;

        [FindsBy(How = How.XPath, Using = "//form[@id='addcoupon']/div[2]/div[2]/div[1]/span/button")]
        private IWebElement GenerateButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='ADD_COUPON']/div[2]/div[1]/div[2]/div[3]/button")]
        private IWebElement SubmitButton;

        [FindsBy(How = How.XPath, Using = "//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[11]/span/a[1]/i")]
        private IWebElement UpdateButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[3]/span[1]/input")]
        private IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = "//div[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[3]/span[1]/span/a")]
        private IWebElement GoButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr/td[5]")]
        private IWebElement NewCoupon;

        [FindsBy(How = How.XPath, Using = "//div[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[6]")]
        private IWebElement EditMaxUses;

        [FindsBy(How = How.XPath, Using = "//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[3]")]
        private IWebElement CouponNumber;

        [FindsBy(How = How.XPath, Using = "//div[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[1]/div[1]/a[2]")]
        private IWebElement PrintButton;


        //Coupons Page constructor
        public CouponsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //PageFactory.InitElements(driver, this)
        }

        //Starting methods for coupons actions.
        private void WaitforCouponsPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(AddButton));
        }

        private void ClickAddButton()
        {
            AddButton.Click();
        }

        private void TypePercentageValue(string percentage)
        {
            System.Threading.Thread.Sleep(3000);
            percentageField.Clear();
            percentageField.SendKeys(percentage);
        }
        private void SubmitCoupon()
        {
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(SubmitButton));
            SubmitButton.Click();
        }
        private void FillCoupon(string percentage)
        {

            TypePercentageValue(percentage);
            wait.Until(ExpectedConditions.ElementToBeClickable(GenerateButton));
            GenerateButton.Click();
            Thread.Sleep(1000);
        }

        private void ClickDeleteButton()
        {
            Thread.Sleep(3000);
            //wait.Until(ExpectedConditions.ElementToBeClickable(DeleteButton));
            DeleteButton.Click();
        }

        private void ConfirmDeleteCoupon()
        {
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.SwitchTo().DefaultContent();
        }

        private void ClickUpdateButton()
        {
            //wait.Until(ExpectedConditions.ElementToBeClickable(UpdateButton));
            System.Threading.Thread.Sleep(3000);
            UpdateButton.Click();
        }

        private void TypeMaxUsesVal(string MaxUses)
        {
            string number = CouponNumber.Text;
            string Xpath = "#editcoupon"+number+"> div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > div:nth-child(2) > input:nth-child(1)";
            //[FindsBy(How = How.CssSelector, Using = )]
            IWebElement MaxUsesField = driver.FindElement(By.CssSelector(Xpath)) ;
            //wait.Until(ExpectedConditions.ElementIsVisible(MaxUsesField));
            System.Threading.Thread.Sleep(3000);
            MaxUsesField.Clear();
            MaxUsesField.SendKeys(MaxUses);
        }

        private void ClickEditCoupon()
        {
            string number = CouponNumber.Text;
            string Xpath = "//div[@id='editCop"+number+"']/div[2]/div[1]/div[4]/button[@id="+number+"]";
            IWebElement EditButton = driver.FindElement(By.XPath(Xpath));
            wait.Until(ExpectedConditions.ElementToBeClickable(EditButton));
            EditButton.Click();
        }

        private void ClickSearchButton()
        {
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(SearchButton));
            SearchButton.Click();
        }

        private void TypeSearchValue(string Value)
        {

            wait.Until(ExpectedConditions.ElementToBeClickable(SearchField));
            SearchField.SendKeys(Value);
        }

        private void ClickGoButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(GoButton));
            GoButton.Click();
        }

        private void ValidateCoupon(string percentage)
        {
            Thread.Sleep(3000);
            string values = NewCoupon.Text;
            Assert.IsTrue(values == percentage);
        }

        private void ValidateEditMaxUses(string MaxUses)
        {
            Thread.Sleep(4000);
            string values = EditMaxUses.Text;
            Assert.IsTrue(values == MaxUses);
        }

        private void ValidateDeletedCoupon(string deletevalue)
        {
            bool exists = false;
            exists = CouponNumber.Displayed.Equals(deletevalue);
            Assert.IsFalse(exists);
        }
        private void SearchCoupon(string Value)
        {
            WaitforCouponsPage();
            ClickSearchButton();
            TypeSearchValue(Value);
            ClickGoButton();
        }

        private void ClickPrintButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(PrintButton));
            PrintButton.Click();
        }

        private void CancelPrintCoupon()
        {
            driver.SwitchTo().ActiveElement();
            driver.SwitchTo().DefaultContent();
        }

        public void AddCoupon(string percentage)
        {
            WaitforCouponsPage();
            ClickAddButton();
            FillCoupon(percentage);
            SubmitCoupon();
            SearchAndVerifyCoupon(percentage);
        }

        public void DeleteCoupon(string value)
        {
            string deletevalue = CouponNumber.Text;

            WaitforCouponsPage();
            SearchCoupon(value);
            ClickDeleteButton();
            //SearchCoupon(value);
            ConfirmDeleteCoupon();
            ValidateDeletedCoupon(deletevalue);
        }

        public void EditCoupon(string MaxUses, string id)
        {
            WaitforCouponsPage();
            SearchCoupon(id);
            ClickUpdateButton();
            TypeMaxUsesVal(MaxUses);
            ClickEditCoupon();
            SearchCoupon(id);
            ValidateEditMaxUses(MaxUses);
        }


        public void SearchAndVerifyCoupon(string Value)
        {
            WaitforCouponsPage();
            ClickSearchButton();
            TypeSearchValue(Value);
            ClickGoButton();
            ValidateCoupon(Value);
        }

        public void PrintCoupons()
        {
            WaitforCouponsPage();
            ClickPrintButton();
            CancelPrintCoupon();
            //ClosePrintWindow);
        }
    }
}
