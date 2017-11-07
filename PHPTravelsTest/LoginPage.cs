using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace PHPTravelsTest
{
    class LoginPage
    {
        private string username;
        private string password;
        private IWebElement element;
        private IWebDriver driver;


        //constructor for ChromeDriver
        public LoginPage(ChromeDriver driver)
        {
            this.driver = driver;
        }

        //constructor for FirefoxDriver
        public LoginPage(FirefoxDriver driver)
        {
            this.driver = driver;
        }



        
        public HomePage fillLogin()
        {
            //[FindsBy(How = How.XPath, Using = "html/body/div[2]/div[2]/form[1]/div[1]/input[1]")]
            //public IWebElement elemento;

            element = driver.FindElementByXPath("html/body/div[2]/div[2]/form[1]/div[1]/input[1]");
            element.SendKeys(username);

            element = driver.FindElementByXPath("html/body/div[2]/div[2]/form[1]/div[1]/input[2]");
            element.SendKeys(password);

            element = driver.FindElementByXPath("html/body/div[2]/div[2]/form[1]/button");
            element.Click();

            return new HomePage();
        }
    }
}
