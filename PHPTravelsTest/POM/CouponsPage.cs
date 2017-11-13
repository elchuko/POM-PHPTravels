using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHPTravelsTest.Utils;

namespace PHPTravelsTest.POM
{
    class CouponsPage : BasicPage
    {

        //Initialize WebDriver(s)
        public IWebDriver driver;
        private WebDriverWait wait;

        //Initialize xpaths variables

        //Coupon Codes Management Top Actions buttons
        [FindsBy(How = How.XPath, Using = ".//button[@class='btn btn-success']")]
        private IWebElement AddButton;

        [FindsBy(How = How.XPath, Using = ".//div[@class='xcrud-top-actions']//a[@data-task='print']")]
        private IWebElement PrintButton;

        [FindsBy(How = How.XPath, Using = ".//div[@class='xcrud-top-actions']//a[@data-task='csv']")]
        private IWebElement ImportIntoCSVButton;

        //Coupon Codes Management Table elements
        [FindsBy(How = How.XPath, Using = ".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[11]/span/a[1]/i")]
        private IWebElement EditButton;

        [FindsBy(How = How.XPath, Using = ".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[11]/span/a[3]/i")]
        private IWebElement DeleteButton;

        [FindsBy(How = How.XPath, Using = ".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[3]")]
        private IWebElement CouponId;

        [FindsBy(How = How.XPath, Using = ".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[5]")]
        private IWebElement PercentageField;

        [FindsBy(How = How.XPath, Using = ".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[6]")]
        private IWebElement MaxUsesField;

        [FindsBy(How = How.XPath, Using = ".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[4]")]
        private IWebElement CouponCodeField;

        //Coupon Codes Management Add Coupons window elements
        [FindsBy(How = How.XPath, Using = ".//form[@id='addcoupon']//input[@id='rate' and @placeholder='Percentage']")]
        //[FindsBy(How = How.Id, Using = "rate")]
        private IWebElement ACPercentageField;

        [FindsBy(How = How.XPath, Using = ".//input[@id='codeadd' and @placeholder='Coupon Code']")]
        private IWebElement ACCouponCodeField;

        [FindsBy(How = How.XPath, Using = ".//form[@id='addcoupon']//button[@id='add']")]
        private IWebElement GenerateButton;

        [FindsBy(How = How.XPath, Using = ".//div[@class='modal-footer']/button[@id='#']")]
        private IWebElement SubmitButton;

        //Coupon Codes Management Search elements
        [FindsBy(How = How.XPath, Using = ".//input[@name='phrase']")]
        private IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = ".//a[@class='xcrud-search-toggle btn btn-default']")]
        private IWebElement SearchButton;

        [FindsBy(How = How.XPath, Using = ".//a[@class='xcrud-action btn btn-primary']")]
        private IWebElement GoButton;

       // [FindsBy(How = How.CssSelector, Using = "tr.xcrud-row:nth-child(2) > td:nth-child(6)")]
       // private IWebElement hardMaxUses;

       // string CouponCode = "";

        //Coupons Page constructor
        public CouponsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            //PageFactory.InitElements(driver, this)
        }

        //Starting methods for coupons actions.

        private void ClickAddButton()
        {
            WebDriverUtils.WaitForElementToBeClickable(driver, AddButton);
            AddButton.Click();
        }

        private void TypePercentageValue(string percentage)
        {
            WebDriverUtils.WaitForElementToBeVisible(driver, ".//form[@id='addcoupon']//input[@id='rate' and @placeholder='Percentage']");
            WebDriverUtils.WaitForElementToBeClickable(driver,ACPercentageField);

            ACPercentageField.Clear();
            ACPercentageField.SendKeys(percentage);
            //CouponCode = percentage.ToString();
        }
        private void ClickSubmitCoupon()
        {
            WebDriverUtils.WaitForElementToBeVisible(driver, ".//div[@class='modal-footer']/button[@id='#']");
            WebDriverUtils.WaitForElementToBeClickable(driver, SubmitButton);

            SubmitButton.Click();
            Thread.Sleep(3000);
        }

        private void ClickGenerateButton()
        {
            WebDriverUtils.WaitForElementToBeVisible(driver, ".//form[@id='addcoupon']//button[@id='add']");
            WebDriverUtils.WaitForElementToBeClickable(driver, GenerateButton);
            GenerateButton.Click();
            Thread.Sleep(3000);
        }

        private void TypeCodeCouponValue(string codecoupon)
        {
            WebDriverUtils.WaitForElementToBeVisible(driver, ".//input[@id='codeadd' and @placeholder='Coupon Code']");
            WebDriverUtils.WaitForElementToBeClickable(driver, ACCouponCodeField);

            ACCouponCodeField.Clear();
            ACCouponCodeField.SendKeys(codecoupon);
        }
        private void FillCouponByPercentageAndGenericCode(string percentage)
        {
            TypePercentageValue(percentage);
            ClickGenerateButton();
        }

        private void FillCouponByPercentageAndDefinedCode(string percentage, string codevalue)
        {
            TypePercentageValue(percentage);
            TypeCodeCouponValue(codevalue);
            WebDriverUtils.WaitForTextToBePresentInElement(driver, CouponCodeField, codevalue);
        }

        private void ClickDeleteButton()
        {
            WebDriverUtils.WaitForElementToBeVisible(driver,".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[11]/span/a[3]/i");
            WebDriverUtils.WaitForElementToBeClickable(driver,DeleteButton);
            DeleteButton.Click();
        }

        private void ConfirmDeleteCoupon()
        {
            WebDriverUtils.WaitForAlertIsPresent(driver);
            IAlert alert = driver.SwitchTo().Alert();

            alert.Accept();
            driver.SwitchTo().DefaultContent();
        }

        private void ClickEditButton()
        {
            Thread.Sleep(2000);
            WebDriverUtils.WaitForElementToBeVisible(driver,".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[11]/span/a[1]/i");
            WebDriverUtils.WaitForElementToBeClickable(driver,EditButton);

            EditButton.Click();
            Thread.Sleep(2000);
        }

        private void TypeMaxUsesVal(string MaxUses)
        {
            string number = CouponId.Text;
            string Xpath = ".//form[contains(@id,'"+number+"')]//input[@placeholder='Maximum Uses']";
            IWebElement MaxUsesField = driver.FindElement(By.XPath(Xpath));

            WebDriverUtils.WaitForElementToBeVisible(driver, Xpath);
            WebDriverUtils.WaitForElementToBeClickable(driver, MaxUsesField);

            MaxUsesField.Clear();
            MaxUsesField.SendKeys(MaxUses);
        }

        private void ClickUpdateButton()
        {
            string number = CouponId.Text;
            string Xpath = ".//div[@id='editCop"+number+"']//button[@id="+number+"]";
            IWebElement UpdateButton = driver.FindElement(By.XPath(Xpath));

            WebDriverUtils.WaitForElementToBeVisible(driver, Xpath);
            WebDriverUtils.WaitForElementToBeClickable(driver, UpdateButton);

            UpdateButton.Click();
            Thread.Sleep(3000);
        }

        private void ClickSearchButton()
        { 
            WebDriverUtils.WaitForElementToBeVisible(driver, ".//a[@class='xcrud-search-toggle btn btn-default']");
            WebDriverUtils.WaitForElementToBeClickable(driver, SearchButton);
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
            string values = PercentageField.Text;
            Assert.IsTrue(values == percentage);
        }

        private void ValidateEditMaxUses(string MaxUses)
        {
            Thread.Sleep(4000);
            string values = MaxUsesField.Text;
            Assert.IsTrue(values == MaxUses);
        }

        private void ValidateDeletedCoupon(string deletevalue)
        {
            bool exists = false;
            exists = CouponId.Displayed.Equals(deletevalue);
            Assert.IsFalse(exists);
        }
        private void SearchCoupon(string Value)
        {
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
            string xpath = "//div[@id='print-header']/div/button[2]";
            IWebElement print = driver.SwitchTo().ActiveElement();
            print.Click();
            driver.SwitchTo().DefaultContent();
        }

        public void AddCouponWithGenericCode(string percentage)
        {
            ClickAddButton();
            FillCouponByPercentageAndGenericCode(percentage);
            ClickSubmitCoupon();
            SearchAndVerifyCoupon(percentage);
        }

        public void AddCouponWithDefinedCode(string percentage, string codevalue)
        {
            ClickAddButton();
            FillCouponByPercentageAndDefinedCode(percentage, codevalue);
            ClickSubmitCoupon();
            SearchAndVerifyCoupon(percentage);
        }

        public void DeleteCoupon(string value)
        {
            string deletevalue; 

            SearchCoupon(value);
            deletevalue = CouponId.Text;
            ClickDeleteButton();
            ConfirmDeleteCoupon();
            ValidateDeletedCoupon(deletevalue);
        }

        public void EditCouponOnMaxUseValue(string MaxUses, string id)
        {
            SearchCoupon(id);
            ClickEditButton();
            TypeMaxUsesVal(MaxUses);
            ClickUpdateButton();
            SearchCoupon(id);
            ValidateEditMaxUses(MaxUses);
        }


        public void SearchAndVerifyCoupon(string Value)
        {
            ClickSearchButton();
            TypeSearchValue(Value);
            ClickGoButton();
            ValidateCoupon(Value);
        }

        public void VerifyMaxUsesModification(string MaxUses)
        {
            //IWebElement table = driver.FindElement(By.ClassName("xcrud-list table table-striped table-hover"));
            //IWebElement row = table.FindElement(By.ClassName("xcrud-row xcrud-row-0"));
            //IReadOnlyCollection<IWebElement> cells = row.FindElements(By.XPath("./*"));

            //NUnit.Framework.Assert.AreEqual(MaxUses, hardMaxUses.Text);
        }

        public void PrintCoupons()
        {
            ClickPrintButton();
            CancelPrintCoupon();
            //ClosePrintWindow);
        }
    }
}
