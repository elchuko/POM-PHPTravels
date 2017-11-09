using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace PHPTravelsTest.POM
{
    class Coupons : BasicPage
    {

        //Initialize WebDriver(s)
        public IWebDriver driver;
        private WebDriverWait wait;

        //Initialize xpaths variables
        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[1]/button")]
        public IWebElement AddButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[11]/span/a[1]")]
        public IWebElement EditButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[11]/span/a[2]/i")]
        public IWebElement SearchButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[11]/span/a[3]/i")]
        public IWebElement DeleteButton;

        [FindsBy(How = How.Id, Using = "rate")]
        public IWebElement percentageField;

        [FindsBy(How = How.XPath, Using = "//*[@id='add']")]
        public IWebElement GenerateButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='btn btn-primary submitcoupon']")]
        public IWebElement SubmitButton;

        public Coupons goToPage(string path)
        {
            driver.Navigate().GoToUrl(path);
            return new Coupons(driver);
        }
        public Coupons(IWebDriver driver): base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //PageFactory.InitElements(driver, this)
        }

        public void WaitforCouponsPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(AddButton));
        }

        public void ClickAddButton()
        {
            AddButton.Click();
        }

        public void TypePercentageValue(string percentage)
        {
            percentageField.SendKeys(percentage);
        }
        public void SubmitCoupon()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(SubmitButton));
            SubmitButton.Click();
        }
        public void FillCoupon(string percentage)
        {
            TypePercentageValue(percentage);
            wait.Until(ExpectedConditions.ElementToBeClickable(GenerateButton));
            GenerateButton.Click();
            Thread.Sleep(1000);
        }

        public void ClickDeleteButton()
        {
            DeleteButton.Click();
        }

        public void ConfirmDeleteCoupon()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.SwitchTo().DefaultContent();
        }

        public void VerifyCouponRemoved(string percentage)
        {
            //pendingCode
        }

        public void AddCoupon(string percentage)
        {
            ClickAddButton();
            FillCoupon(percentage);
            SubmitCoupon();
        }

        private void DeleteCoupon(string percentage)
        {
            ClickDeleteButton();
            ConfirmDeleteCoupon();
            //VerifyCouponRemoved(percentage);
        }
    }
}
