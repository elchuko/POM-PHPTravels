using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHPTravelsTest.Utils;
using PHPTravelsTest.POM.Validations;

namespace PHPTravelsTest.POM
{
    public class CouponsPage : BasicPage
    {

        //Initialize WebDriver(s)
        public IWebDriver driver;

        private static readonly log4net.ILog Logger = Utils.Logger.GetLoggerInstance();

        //Initialize xpaths variables

        //Go to Coupons banner
        [FindsBy(How = How.XPath, Using = ".//ul[@id='social-sidebar-menu']/li[12]/a/span")]
        private IWebElement CouponsPageButton;

        //Coupon Codes Management Top Actions buttons
        [FindsBy(How = How.XPath, Using = ".//button[@class='btn btn-success']")]
        private IWebElement AddButton;

        [FindsBy(How = How.XPath, Using = ".//div[@class='xcrud-top-actions']//a[@data-task='print']")]
        private IWebElement PrintButton;

        [FindsBy(How = How.XPath, Using = ".//div[@class='xcrud-top-actions']//a[@data-task='csv']")]
        private IWebElement ImportIntoCSVButton;

        //Coupon Codes Management Table elements
        [FindsBy(How = How.XPath, Using = ".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[11]/span/a[1]/i")]
        public IWebElement EditButton;

        [FindsBy(How = How.XPath, Using = ".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[11]/span/a[3]/i")]
        private IWebElement DeleteButton;

        [FindsBy(How = How.XPath, Using = ".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[3]")]
        internal IWebElement CouponId;

        [FindsBy(How = How.XPath, Using = ".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[5]")]
        internal IWebElement PercentageField;

        [FindsBy(How = How.XPath, Using = ".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[6]")]
        internal IWebElement MaxUsesField;

        [FindsBy(How = How.XPath, Using = ".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[4]")]
        internal IWebElement CouponCodeField;

        [FindsBy(How = How.XPath, Using = ".//tr[@class='xcrud-row']/td")]
        internal IWebElement NoFoundElementsField;

        internal string TableFrameXpath = ".//table[@class='xcrud-list table table-striped table-hover']/tbody";

        //Coupon Codes Management Add Coupons window elements
        [FindsBy(How = How.XPath, Using = ".//form[@id='addcoupon']//input[@id='rate' and @placeholder='Percentage']")]
        private IWebElement ACPercentageField;

        [FindsBy(How = How.XPath, Using = ".//input[@id='codeadd' and @placeholder='Coupon Code']")]
        private IWebElement ACCouponCodeField;

        [FindsBy(How = How.XPath, Using = ".//form[@id='addcoupon']//button[@id='add']")]
        private IWebElement GenerateButton;

        [FindsBy(How = How.XPath, Using = ".//div[@class='modal-footer']/button[@id='#']")]
        private IWebElement SubmitButton;

        [FindsBy(How = How.XPath, Using = ".//div[@class='modal-footer']")]
        private IWebElement LoadingMessage;

        //Coupon Codes Management Search elements
        [FindsBy(How = How.XPath, Using = ".//input[@name='phrase']")]
        private IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = ".//a[@class='xcrud-search-toggle btn btn-default']")]
        private IWebElement SearchButton;

        [FindsBy(How = How.XPath, Using = ".//a[@class='xcrud-action btn btn-primary']")]
        private IWebElement GoButton;


        //Coupons Page constructor
        public CouponsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;

        }

        //Starting methods for coupons actions.

        public void goToCouponsPage()
        {
            Logger.Info("goToCouponsPage");
            WebDriverUtils.WaitForElementToBeClickable(driver, CouponsPageButton);
            CouponsPageButton.Click();
        }
        private void ClickAddButton()
        {
            Logger.Info("ClickAddButton");
            WebDriverUtils.WaitForElementToBeVisible(driver, ".//button[@class='btn btn-success']");
            WebDriverUtils.WaitForElementToBeClickable(driver, AddButton);

            AddButton.Click();
        }

        private void TypePercentageValue(string percentage)
        {
            Logger.Info("TypePercentageValue");
            WebDriverUtils.WaitForElementToBeVisible(driver, ".//form[@id='addcoupon']//input[@id='rate' and @placeholder='Percentage']");
            WebDriverUtils.WaitForElementToBeClickable(driver,ACPercentageField);

            ACPercentageField.Clear();
            ACPercentageField.SendKeys(percentage);
        }

        private void ClickGenerateButton()
        {
            Logger.Info("ClickGenerateButton");
            WebDriverUtils.WaitForElementToBeVisible(driver, ".//form[@id='addcoupon']//button[@id='add']");
            WebDriverUtils.WaitForElementToBeClickable(driver, GenerateButton);

            GenerateButton.Click();
 
            WebDriverUtils.WaitForElementHasText(driver);
        }

        private string ClickSubmitCoupon()
        {
            string CouponCode;
            Logger.Info("ClickSubmitCoupon");

            CouponCode = WebDriverUtils.GetInputText(ACCouponCodeField);

            WebDriverUtils.WaitForElementToBeVisible(driver, ".//div[@class='modal-footer']/button[@id='#']");
            WebDriverUtils.WaitForElementToBeClickable(driver, SubmitButton);

            SubmitButton.Click();

            WebDriverUtils.WaitForInvisibilityOfElementLocated(driver, "//*[@id='ADD_COUPON']");

            return CouponCode;
        }


        private void TypeCodeCouponValue(string codecoupon)
        {
            Logger.Info("TypeCodeCouponValue");
            WebDriverUtils.WaitForElementToBeVisible(driver, ".//input[@id='codeadd' and @placeholder='Coupon Code']");
            WebDriverUtils.WaitForElementToBeClickable(driver, ACCouponCodeField);

            ACCouponCodeField.Clear();
            ACCouponCodeField.SendKeys(codecoupon);
        }

        private void FillCouponByPercentageAndDefinedCode(string percentage, string codevalue)
        {
            Logger.Info("FillCouponByPercentageAndDefinedCode");
            TypePercentageValue(percentage);
            TypeCodeCouponValue(codevalue);
            WebDriverUtils.WaitForTextToBePresentInElement(driver, CouponCodeField, codevalue);
        }

        private void ClickDeleteButton()
        {
            Logger.Info("ClickDeleteButton");
            WebDriverUtils.WaitForElementToBeVisible(driver,".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[11]/span/a[3]/i");
            WebDriverUtils.WaitForElementToBeClickable(driver,DeleteButton);

            DeleteButton.Click();
        }

        private void ConfirmDeleteCoupon()
        {
            Logger.Info("ConfirmDeleteCoupon");
            WebDriverUtils.WaitForAlertIsPresent(driver);
            IAlert alert = driver.SwitchTo().Alert();

            alert.Accept();
            driver.SwitchTo().DefaultContent();
        }

        private void ClickEditButton()
        {
            Logger.Info("ClickEditButton");
            WebDriverUtils.WaitForElementToBeVisible(driver,".//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[11]/span/a[1]/i");
            WebDriverUtils.WaitForElementToBeClickable(driver,EditButton);

            EditButton.Click();
        }

        private void TypeMaxUsesVal(string MaxUses)
        {
            Logger.Info("TypeMaxUsesVal");
            string number = CouponId.Text;
            string Xpath = ".//form[contains(@id,'"+number+"')]//input[@placeholder='Maximum Uses']";

            WebDriverUtils.WaitForElementToBeVisible(driver, "//*[@id='editCop"+number+"']");
            IWebElement MaxUsesField = driver.FindElement(By.XPath(Xpath));

            WebDriverUtils.WaitForElementToBeVisible(driver, Xpath);
            WebDriverUtils.WaitForElementToBeClickable(driver, MaxUsesField);

            MaxUsesField.Clear();
            MaxUsesField.SendKeys(MaxUses);
        }

        private void ClickUpdateButton()
        {
            Logger.Info("Click Update Button");
            string number = CouponId.Text;
            string Xpath = ".//div[@id='editCop"+number+"']//button[@id="+number+"]";
            IWebElement UpdateButton = driver.FindElement(By.XPath(Xpath));

            WebDriverUtils.WaitForElementToBeVisible(driver, Xpath);
            WebDriverUtils.WaitForElementToBeClickable(driver, UpdateButton);

            UpdateButton.Click();
            WebDriverUtils.WaitForInvisibilityOfElementLocated(driver, "//*[@id='editCop" + number + "']");
        }

        private void ClickSearchButton()
        { 
            Logger.Info("clickSearchButton");
            WebDriverUtils.WaitForElementToBeVisible(driver, ".//a[@class='xcrud-search-toggle btn btn-default']");
            WebDriverUtils.WaitForElementToBeClickable(driver, SearchButton);

            SearchButton.Click();
        }

        private void TypeSearchValue(string Value)
        {
            Logger.Info("TypoeSearchValue");
            WebDriverUtils.WaitForElementToBeClickable(driver,SearchField);
            SearchField.SendKeys(Value);
        }

        private void ClickGoButton()
        {
            Logger.Info("ClickGoButton");
            WebDriverUtils.WaitForElementToBeClickable(driver,GoButton);
            GoButton.Click();
        }

        private string ClickPrintButton()
        {
            Logger.Info("ClickPrintButton");
            string ParentWindow = driver.CurrentWindowHandle;

            WebDriverUtils.WaitForElementToBeClickable(driver,PrintButton);
            PrintButton.Click();

            foreach (string window in driver.WindowHandles)
            {
                driver.SwitchTo().Window(window);
            }
            return ParentWindow;
        }

        private void ClosePrintCoupon(string ParentWindow)
        {
            driver.Close();
            driver.SwitchTo().Window(ParentWindow);
        }


        public  string AddCouponWithGenericCode(string percentage)
        {
            Logger.Info("inside AddCouponWithGenericCode");
            string CodeValue;

            ClickAddButton();
            Logger.Info("Type Percentage Value");
            TypePercentageValue(percentage);
            ClickGenerateButton();

            CodeValue = ClickSubmitCoupon();
            return CodeValue;
        }

        /*Not required so far.
         * public void AddCouponWithDefinedCode(string percentage, string codevalue)
        {
            ClickAddButton();
            FillCouponByPercentageAndDefinedCode(percentage, codevalue);
            ClickSubmitCoupon();
            SearchCoupon(codevalue);
            CouponsPageValidations.ValidateCouponbyPercentage(percentage);
            CouponsPageValidations.ValidateCouponbyCouponCode(codevalue);
        }*/

        public void DeleteCoupon(string value)
        {
            Logger.Info("Delete Coupon");
            WebDriverUtils.WaitForElementToBeClickable(driver,AddButton);

            ClickDeleteButton();
            ConfirmDeleteCoupon();

        }

        public void EditCouponOnMaxUseValue(string MaxUses)
        {
            Logger.Info("EditCouponOnMaxUseValue");
            WebDriverUtils.WaitForElementToBeClickable(driver, AddButton);

            ClickEditButton();
            TypeMaxUsesVal(MaxUses);
            ClickUpdateButton();
        }


        public void SearchCoupon(string Value)
        {
            Logger.Info("SearchCoupon " + Value);
            WebDriverUtils.WaitForElementToBeClickable(driver, AddButton);

            ClickSearchButton();
            TypeSearchValue(Value);
            ClickGoButton();
        }

        public String OpenPrintWindow()
        {
            Logger.Info("OpenPrintWindow");
            WebDriverUtils.WaitForElementToBeClickable(driver, AddButton);

            string ParentWindow = ClickPrintButton();
            return ParentWindow;
        }

        public void ClosePrintWindow(string ParentWindow)
        {
            Logger.Info("ClosePrintWindow");
            ClosePrintCoupon(ParentWindow);
        }
    }
}
