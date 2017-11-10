using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

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

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[11]/span/a[1]")]
        private IWebElement EditButton;

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

        [FindsBy(How = How.Id, Using = "11")]
        private IWebElement UpdateButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[3]/span[1]/input")]
        private IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[3]/span[1]/span/a")]
        private IWebElement GoButton;

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
            wait.Until(ExpectedConditions.ElementToBeClickable(AddButton));
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
            //driver.SwitchTo().Frame();
            //wait.Until(ExpectedConditions.ElementIsVisible(MaxUsesField));
            System.Threading.Thread.Sleep(3000);
            MaxUsesField.Clear();
            MaxUsesField.SendKeys(MaxUses);
        }

        private void ClickEditCoupon()
        {
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
        //Starting methods for coupons actions
        /*public CouponsPage goToPage(string path)
        {
            driver.Navigate().GoToUrl(path);
            return new CouponsPage(driver);
        }*/

        public void AddCoupon(string percentage)
        {
            WaitforCouponsPage();
            ClickAddButton();
            FillCoupon(percentage);
            SubmitCoupon();
        }

        public void DeleteCoupon()
        {
            WaitforCouponsPage();
            ClickDeleteButton();
            ConfirmDeleteCoupon();
        }

        public void EditCoupon(string MaxUses)
        {
            WaitforCouponsPage();
            ClickEditCoupon();
            TypeMaxUsesVal(MaxUses);
            ClickUpdateButton();
        }

        public void SearchCoupon(string Value)
        {
            WaitforCouponsPage();
            ClickSearchButton();
            TypeSearchValue(Value);
            ClickGoButton();
        }
    }
}
