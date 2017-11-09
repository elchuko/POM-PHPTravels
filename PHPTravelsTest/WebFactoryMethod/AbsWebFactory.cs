using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PHPTravelsTest.WebFactoryMethod
{
    public abstract class AbsWebFactory
    {
        public abstract IWebDriver GetWebDriver (string browser);
    }
}
