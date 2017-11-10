using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PHPTravelsTest.POM
{
    class CouponsPage : BasicPage
    {

        //Initialize WebDriver(s)
        public IWebDriver driver;
        private WebDriverWait wait;

        //Initialize xpaths variables
        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[1]/button")]
        private IWebElement AddButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='editCop11']/div[2]/div[1]/div[4]/button[@id=11]")]
        private IWebElement EditButton;
        ////*[@id="content"]/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[11]/span/a[1]/i

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[3]/a")]
        private IWebElement SearchButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[11]/span/a[3]/i")]
        private IWebElement DeleteButton;

        [FindsBy(How = How.Id, Using = "rate")]
        private IWebElement percentageField;

        [FindsBy(How = How.XPath, Using = "//*[@id='add']")]
        private IWebElement GenerateButton;

        [FindsBy(How = How.Id, Using = "#")]
        private IWebElement SubmitButton;

        [FindsBy(How = How.CssSelector, Using = "#editcoupon11 > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > div:nth-child(2) > input:nth-child(1)")]
        private IWebElement MaxUsesField;

        [FindsBy(How = How.XPath, Using = "//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[11]/span/a[1]/i")]
        private IWebElement UpdateButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[3]/span[1]/input")]
        private IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[3]/span[1]/span/a")]
        private IWebElement GoButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr/td[5]")]
        private IWebElement NewCoupon;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[6]")]
        private IWebElement EditMaxUses;

        [FindsBy(How = How.XPath, Using = "//table[@class='xcrud-list table table-striped table-hover']//tr[1]/td[3]")]
        private IWebElement CouponNumber;


        //Coupons Page constructor
        public CouponsPage(IWebDriver driver): base(driver)
        {
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
            DeleteButton.Click();
        }

        private void ConfirmDeleteCoupon()
        {
            System.Threading.Thread.Sleep(2000);
            IAlert alert = driver.SwitchTo().Alert();
            driver.SwitchTo().Alert().Accept();
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
            //driver.SwitchTo().Frame();
            //wait.Until(ExpectedConditions.ElementIsVisible(MaxUsesField));
            System.Threading.Thread.Sleep(3000);
            MaxUsesField.Clear();
            MaxUsesField.SendKeys(MaxUses);
        }

        private void ClickEditCoupon()
        {
            //string number = CouponNumber.Text;
            //string Xpath = "//div[@class='modal-footer']/button[@id=" + number+"]";
            //IWebElement  Update = driver.FindElement(By.XPath(Xpath));
            wait.Until(ExpectedConditions.ElementToBeClickable(EditButton));
            EditButton.Click();
        }

        private void ClickSearchButton()
        {
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
            string values = NewCoupon.Text;
            Assert.IsTrue(values == percentage);
        }

        private void ValidateEditMaxUses(string MaxUses)
        {
            string values = EditMaxUses.Text;
            Assert.IsTrue(values == MaxUses);
        }

        private void ValidateDeletedCoupon(string deletevalue)
        {
            bool exists = false;
            exists = CouponNumber.Displayed.Equals(deletevalue);
            Assert.IsFalse(exists);
        }
        public void AddCoupon(string percentage)
        {
            WaitforCouponsPage();
            ClickAddButton();
            FillCoupon(percentage);
            SubmitCoupon();
            SearchCoupon(percentage);
            ValidateCoupon(percentage);
        }

        public void DeleteCoupon()
        {
            string deletevalue = CouponNumber.Text;

            WaitforCouponsPage();
            ClickDeleteButton();
            ConfirmDeleteCoupon();
            ValidateDeletedCoupon(deletevalue);
        }

        public void EditCoupon(string MaxUses)
        {
            WaitforCouponsPage();
            ClickUpdateButton();
            TypeMaxUsesVal(MaxUses);
            ClickEditCoupon();
            ValidateEditMaxUses(MaxUses);
        }

        public void SearchCoupon(string Value)
        {
            WaitforCouponsPage();
            ClickSearchButton();
            TypeSearchValue(Value);
            ClickGoButton();
            ValidateCoupon(Value);
        }

    }
}
