using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PHPTravelsTest.WebFactory
{
    public class ConWebDriver: AbsWebDriver
    {
        public ConWebDriver()
        {
            
        }

        public IWebDriver ReturnDriver()
        {
            return new ChromeDriver();
        }
    }
}
