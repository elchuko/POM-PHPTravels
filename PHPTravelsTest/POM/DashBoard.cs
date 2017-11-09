using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PHPTravelsTest
{
    class DashBoard: BasicPage
    {
        private IWebDriver driver;
        private string CurrentURL = null;
        private string URL = "jdfkaldfa";//this should not be hardcoded

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
