using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PHPTravelsTest.POM
{
    class Coupons
    {

        //Initialize xpaths variables
        public IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[1]/button")]
        public IWebElement AddButton;
       
        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[11]/span/a[1]")]
        public IWebElement EditButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[11]/span/a[2]/i")]
        public IWebElement SearchButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td[11]/span/a[3]/i")]
        public IWebElement DeleteButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='#, @name='status']")]
        public IWebElement StatusField;

        [FindsBy(How = How.XPath, Using = "//*[@id='rate']")]
        public IWebElement percentageField;

        [FindsBy(How = How.XPath, Using = "//*[@id='max']")]
        public IWebElement MaxUsesField;

        [FindsBy(How = How.XPath, Using = "//*[@id='stardate']")]
        public IWebElement StartDateField;

        [FindsBy(How = How.XPath, Using = "//*[@id='expdate']")]
        public IWebElement ExpDateField;

        [FindsBy(How = How.XPath, Using = "//*[@id='addcoupon']/div[2]/div[1]/div[2]/div/div[1]/ins")]
        public IWebElement AssGloCheckbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='add']")]
        public IWebElement GenerateButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='s2id_autogen1']/ul")]
        public IWebElement AssHotelButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='s2id_autogen3']/ul")]
        public IWebElement AssTourButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='s2id_autogen5']/ul")]
        public IWebElement AssCarButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='#'and @Type = 'button']")]
        public IWebElement SubmitButton;

        public void ClickAddButton()
        {
            AddButton.Click();
        }

        public void SelectStatusValue(string statusVal)
        {
            var Select_status = new SelectElement(StatusField);
            Select_status.SelectByText(statusVal);
        }
        public void FillCoupon(string status)
        {

            SelectStatusValue(status);
            percentageField.SendKeys("30");
            MaxUsesField.SendKeys("50");
            StartDateField.SendKeys("07/11/2017");
            StartDateField.Click();
            ExpDateField.SendKeys("07/12/2017");
            ExpDateField.Click();
            AssGloCheckbox.Click();
            GenerateButton.Click();
        }

        public void AddCouppon(string status, string percentage, string MaxUses, string StartDate, string ExpDate)
        {
            ClickAddButton();
            FillCoupon(status);
            SubmitButton.Click();
        }

        

        private void EditCouppon()
        {

        }
    }
}
