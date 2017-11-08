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
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PHPTravelsTest
{
    class MyProfilePage: BasicPage
    {
        private IWebDriver driver;
        public MyProfilePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //webElements declaration
        [FindsBy(How = How.XPath, Using = "//*[@id='content']/form/div/div[2]/div/div[2]/div/input")]
        private IWebElement txtboxFirstName;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/form/div/div[2]/div/div[3]/div/input")]
        private IWebElement txtboxLastName;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/form/div/div[2]/div/div[4]/div/input")]
        private IWebElement txtboxEmail;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/form/div/div[2]/div/div[6]/div/input")]
        private IWebElement txtboxMobile;

        [FindsBy(How = How.XPath, Using = "//*[@id='select2-drop-mask']")]
        private IWebElement dropdownCountry;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/form/div/div[2]/div/div[9]/div/input")]
        private IWebElement txtboxAddress1;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/form/div/div[2]/div/div[10]/div/input")]
        private IWebElement txtboxAddress2;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/form/div/div[3]/button")]
        private IWebElement bttnSubmit;


        //Methods Declaration

        //We verify we are in MyProfilePage
        public bool VerifyWeAreMyProfilePage()
        {
           return true;
        }

        public void WriteFirstName(string firstName)
        {
            txtboxFirstName.SendKeys(firstName);

        }

        public string GetFirstName(string firstName)
        {
            return null;
        }

        public void WriteLastName(string lastName)
        {
            txtboxLastName.SendKeys(lastName);
        }

        public string GetLastName()
        {
            return null;
        }

        public void WriteMail(string mail)
        {
            txtboxEmail.SendKeys(mail);
        }

        public string GetMail()
        {
            return null;
        }

        public void WriteMobileNumber(string mobileNumber)
        {
            txtboxMobile.SendKeys(mobileNumber);
        }

        public string GetMobileNumber()
        {
            return null;
        }

        public void WriteCountry(string country)
        {
            dropdownCountry.SendKeys(country);
        }

        public string GetCountry()
        {
            return null;
        }

        public void WriteAddress1(string address1)
        {
            txtboxAddress1.SendKeys(address1);
        }

        public string GetAddress1()
        {
            return null;
        }

        public void WriteAddress2(string address2)
        {
            txtboxAddress2.SendKeys(address2);
        }

        public string GetAddress2()
        {
            return null;
        }

        public void clickSubmitButton()
        {
            bttnSubmit.Click();
        }

        public void MethodForTestCase(string name)
        {
            WriteFirstName(name);
            clickSubmitButton();
        }
    }
}
