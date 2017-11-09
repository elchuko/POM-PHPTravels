using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using PHPTravelsTest.POM;

namespace PHPTravelsTest
{
    class LoginPage : BasicPage
    {
        //private string username;
        //private string password;
        private IWebDriver driver;

        //constructor for ChromeDriver
        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }


        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div[2]/form[1]/div[1]/input[1]")]
        private IWebElement txtboxUsername;

        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div[2]/form[1]/div[1]/input[2]")]
        private IWebElement txtboxPassword;

        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div[2]/form[1]/button")]
        private IWebElement loginButton;


        public void SendUsername(string username)
        {
            txtboxUsername.SendKeys(username);
        }

        public void SendPassword(string password)
        {
            txtboxPassword.SendKeys(password);
        }

        public void ClickButton()
        {
            loginButton.Click();
        }

        public void FillLogin(string username, string password)
        {
            
            SendUsername(username);
            System.Threading.Thread.Sleep(3000);
            SendPassword(password);
            System.Threading.Thread.Sleep(3000);
            ClickButton();
        //return PageFactory.GetPage();
        }

    }
}
