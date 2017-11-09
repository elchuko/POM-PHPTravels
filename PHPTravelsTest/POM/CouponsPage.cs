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

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[11]/span/a[2]/i")]
        private IWebElement SearchButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[11]/span/a[3]/i")]
        private IWebElement DeleteButton;

        [FindsBy(How = How.Id, Using = "rate")]
        private IWebElement percentageField;

        [FindsBy(How = How.XPath, Using = "//*[@id='add']")]
        private IWebElement GenerateButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='btn btn-primary submitcoupon']")]
        private IWebElement SubmitButton;

        [FindsBy(How = How.CssSelector, Using = "html body.pace-done.modal-open div.wrapper div.main div#content.container div#editCop11.modal.fade.in div.modal-dialog.modal-lg div.modal-content div.modal-body form#editcoupon11.form-horizontal div div div.panel-body div.spacer20px div.col-lg-5 div.well div.form-group div.col-md-6 input#max.form-control")]
        private IWebElement MaxUsesField;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='11']")]
        private IWebElement UpdateButton;

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
            wait.Until(ExpectedConditions.ElementToBeClickable(UpdateButton));
            UpdateButton.Click();
        }

        private void TypeMaxUsesVal(string MaxUses)
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(MaxUsesField));
            MaxUsesField.SendKeys(MaxUses);
        }

        private void ClickEditCoupon()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(EditButton));
            EditButton.Click();
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
            IWebElement startdate = driver.FindElement(By.XPath("//*[@id='stardate']"));
            TypeMaxUsesVal(MaxUses);
            ClickUpdateButton();
        }
    }
}
