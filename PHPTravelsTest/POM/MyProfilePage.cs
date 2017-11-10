using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PHPTravelsTest
{
    class MyProfilePage : BasicPage
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
        public bool VerifyWeAreMyProfilePage()
        {
            return true;
        }

        public void WriteFirstName(string firstName)
        {
            txtboxFirstName.Clear();
            txtboxFirstName.SendKeys(firstName);
        }

        public string GetFirstName(string firstName)
        {
            return null;
        }

        public void WriteLastName(string lastName)
        {
            txtboxLastName.Clear();
            txtboxLastName.SendKeys(lastName);
        }

        public string GetLastName()
        {
            return null;
        }

        public void WriteMail(string mail)
        {

            txtboxEmail.Clear();
            txtboxEmail.SendKeys(mail);
        }

        public string GetMail()
        {
            return null;
        }

        public void WriteMobileNumber(string mobileNumber)
        {
            txtboxMobile.Clear();
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
            txtboxAddress1.Clear();
            txtboxAddress1.SendKeys(address1);
        }

        public string GetAddress1()
        {
            return null;
        }

        public void WriteAddress2(string address2)
        {
            txtboxAddress2.Clear();
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

        public void WriteFieldValues
            (
            string firstname,
            string lastname,
            string mail,
            string mobile,
            string country,
            string address1,
            string address2
            )
        {
            if (firstname != null) WriteFirstName(firstname);
            if (lastname != null) WriteLastName(lastname);
            if (mail != null) WriteMail(mail);
            if (mobile != null) WriteMail(mobile);
            if (country != null) WriteMail(country);
            if (address1 != null) WriteMail(address1);
            if (address2 != null) WriteMail(address2);
        }

        public void VerifyValue
            (
            string firstname,
            string lastname,
            string mail,
            string mobile,
            string country,
            string address1,
            string address2
            )
        {
            if (firstname != null) VerifyFirstName(firstname);
            
        }


        public void VerifyFirstName(string name)
        {
            Assert.AreEqual(txtboxFirstName.GetAttribute("value"), name);
        }
        //public void IsNull(Func<string,int> mymethod)
        //{



        //}
    }
}
