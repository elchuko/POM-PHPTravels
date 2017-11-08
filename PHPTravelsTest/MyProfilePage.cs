using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PHPTravelsTest
{
    class MyProfilePage: BasicPage
    {
        private IWebDriver driver;
        public MyProfilePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
    }
}
