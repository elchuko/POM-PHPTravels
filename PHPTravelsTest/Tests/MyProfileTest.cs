using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using PHPTravelsTest.WebFactoryMethod;
using System.Collections.Generic;
using System.Net;

namespace PHPTravelsTest
{

    //Enum for the Browsers to be used
    public enum Browsers
    {
        Chrome,
        Firefox,
        IE
    };

    [TestClass]
    public class MyProfileTest
    {   
        
        private IWebDriver driver;

        Dictionary<string, string> KeyWords = new Dictionary<string, string>();

        [SetUp]
        public void SetUp()
        {
            WebFactory webFactory = new WebFactory();
            driver = webFactory.GetWebDriver(Browsers.Chrome.ToString());
            driver.Navigate().GoToUrl("http://www.phptravels.net/admin");
            driver.Manage().Window.Maximize();

            //Setup values
            KeyWords.Add("firstname", "Eusebio");
            KeyWords.Add("lastname", null);
            KeyWords.Add("mail", null);
            KeyWords.Add("mobile", null);
            KeyWords.Add("country", null);
            KeyWords.Add("address1", null);
            KeyWords.Add("address2", null);
            KeyWords.Add("username","admin@phptravels.com");
            KeyWords.Add("password", "demoadmin");




        }


        [Test]
        public void MyProfileTestCase()
        {

            var username = KeyWords["username"];
            var password = KeyWords["password"];
            var firstname = KeyWords["firstname"];
            var lastname = KeyWords["lastname"];
            var mail = KeyWords["mail"];
            var mobile = KeyWords["mobile"];
            var country = KeyWords["country"];
            var address1 = KeyWords["address1"];
            var address2 = KeyWords["address2"];

            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(username, password);
            DashBoard dashBoard = new DashBoard(driver);
            dashBoard.goMyProfile();
            MyProfilePage myProfile = new MyProfilePage(driver);
            myProfile.WriteFieldValues(firstname,lastname,mail,mobile,country,address1,address2);
            
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}

