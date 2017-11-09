using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace PHPTravelsTest.WebFactoryMethod
{
    public class WebFactory: AbsWebFactory
    {
        public override IWebDriver GetWebDriver(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    return new ChromeDriver(new ChromeOptions());
                    break;

                case "Firefox":
                    return new FirefoxDriver(new FirefoxOptions());
                    break;

                case "IE":
                    return new InternetExplorerDriver(new InternetExplorerOptions());
                    break;
            }
            return null;
        }
    }
}
