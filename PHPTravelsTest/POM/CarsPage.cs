using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PHPTravelsTest.Utils;

namespace PHPTravelsTest.POM
{
    class CarsPage: BasicPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/form/button")]
        private IWebElement add;

        [FindsBy(How = How.XPath, Using = "//*[@id='GENERAL']/div[3]/div/input")]
        private IWebElement carNameTxtbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='add']")]
        private IWebElement submitButton;

        public CarsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void AddCar(string carName)
        {
            WebDriverUtils.WaitForElementToBeVisible(driver, "//*[@id='content']/div/form/button");
            add.Click();

            WebDriverUtils.WaitForElementToBeVisible(driver, "//*[@id='GENERAL']/div[3]/div/input");
            carNameTxtbox.Clear();
            carNameTxtbox.SendKeys(carName);
            submitButton.Click();
            System.Threading.Thread.Sleep(2000);
        }



        
    }
}
