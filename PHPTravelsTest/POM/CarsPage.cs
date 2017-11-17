using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PHPTravelsTest.Utils;

namespace PHPTravelsTest.POM
{
    public class CarsPage: BasicPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/form/button")]
        private IWebElement add;

        [FindsBy(How = How.XPath, Using = "//*[@id='GENERAL']/div[3]/div/input")]
        private IWebElement carNameTxtbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='add']")]
        private IWebElement submitButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div[2]/div/div/div[1]/div[3]/a")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div[2]/div/div/div[1]/div[3]/span[1]/input")]
        private IWebElement searchTxtbox;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div[2]/div/div/div[1]/div[3]/span[1]/span/a")]
        private IWebElement goButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div[2]/div/div/div[1]/div[2]/table/tbody/tr/td[5]/a")]
        private IWebElement searchResultName;

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

        public string ValidateAddedCar(string carName)
        {
            WebDriverUtils.WaitForElementToBeVisible(driver, "//*[@id='content']/div/div[2]/div/div/div[1]/div[3]/a");
            searchButton.Click();
            WebDriverUtils.WaitForElementToBeVisible(driver, "//*[@id='content']/div/div[2]/div/div/div[1]/div[3]/span[1]/input");
            searchTxtbox.Clear();
            searchTxtbox.SendKeys(carName);
            goButton.Click();
            return searchResultName.Text;
        }






    }
}
