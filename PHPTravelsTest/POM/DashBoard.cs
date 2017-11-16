using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using PHPTravelsTest.POM;
using PHPTravelsTest.Utils;

namespace PHPTravelsTest
{
    class DashBoard: BasicPage
    {
        private IWebDriver driver;
        //private string CurrentURL = null;
        //private string URL = "jdfkaldfa";//this should not be hardcoded

        public DashBoard(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void goMyProfile()
        {
            LeftSideBanner banner = new LeftSideBanner(driver);
            banner.GoToMyProfile();
            System.Threading.Thread.Sleep(3000);
        }

        public CouponsPage goToCouponsPage()
        {
            LeftSideBanner banner = new LeftSideBanner(driver);
            banner.GoToCouponsPage();

            return new CouponsPage(driver);
        }

        public void GoCarsSubMenu()
        {
            LeftSideBanner banner = new LeftSideBanner(driver);
            banner.GoToCarsInsideCarsMenu();
            Thread.Sleep(1000);

        }

        public void GoExtrasSubMenu()
        {
            LeftSideBanner banner = new LeftSideBanner(driver);
            banner.GoToExtrasInsideCarsMenu();
            Thread.Sleep(1000);
        }

        public void GoSettingsSubMenu()
        {
            LeftSideBanner banner = new LeftSideBanner(driver);
            banner.GoToCarSettingsInsideCarsMenu();
            Thread.Sleep(1000);
        }


        //public bool VerifyWeAreDashBoard()
        //{
        //    CurrentURL = driver.Url;
        //    if (CurrentURL.Equals(URL))
        //    {
        //        return true;
        //    }
        //    else return false;
        //}
    }
}
