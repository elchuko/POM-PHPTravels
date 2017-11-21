using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using PHPTravelsTest.WebFactoryMethod;
using System.Collections.Generic;
using System.Net;
using System.Configuration;
using PHPTravelsTest.POM;
using PHPTravelsTest.Utils;

namespace PHPTravelsTest
{

    //Enum for the Browsers to be used

    [TestFixture]
    public class MyProfileTest
    {   
        
        private IWebDriver driver;
        private static readonly log4net.ILog Logger = Utils.Logger.GetLoggerInstance();

        [SetUp]
        public void SetUp()
        {
            driver = SetUpClass.SetUp(driver);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.FillLogin(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
        }


        [Test] public void TC33_MyProfile_Modified_ProfileSuccesfully()
        {
            Logger.Info("Test Case Name TC33_MyProfile_Modified_ProfileSuccesfully");
            var firstname = ConfigurationManager.AppSettings["firstname"];
            var lastname = ConfigurationManager.AppSettings["lastname"];
            var mail = ConfigurationManager.AppSettings["mail"];
            var mobile = ConfigurationManager.AppSettings["mobile"];
            var country = ConfigurationManager.AppSettings["country"];
            var address1 = ConfigurationManager.AppSettings["address1"];
            var address2 = ConfigurationManager.AppSettings["address2"];


            DashBoard dashBoard = new DashBoard(driver);
            Logger.Info("Go to My Profile");
            dashBoard.goMyProfile();
            MyProfilePage myProfile = new MyProfilePage(driver);
            Logger.Info("Write Field Values Firstname " + firstname + 
                " Lastname "+ lastname + 
                " mail "+ mail +
                " mobile "+ mobile + 
                " Country " + country + 
                " address1 " + address1 + 
                " address 2 "+address2);
            myProfile.WriteFieldValues(firstname,lastname,mail,mobile,country,address1,address2);
            Logger.Info("VerifyValue with values passed as parameters");
            myProfile.VerifyValue(firstname, lastname, mail, mobile, country, address1, address2);
            
        }

        [TearDown]
        public void CleanUp()
        {
            CleanUpClass.CloseAndClean(driver);
        }
    }
}

