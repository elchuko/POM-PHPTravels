using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PHPTravelsTest
{
    class HomePage: BasicPage
    {
        private IWebDriver driver;
        private string CurrentURL = null;
        private string URL = "jdfkaldfa";//this should not be hardcoded

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
       
        public bool VerifyWeAreHome()
        {
            CurrentURL = driver.Url;
            if (CurrentURL.Equals(URL))
            {
                return true;
            }
            else return false;
        }
    }
}
