using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PHPTravelsTest.Validations
{
    class CarsValidations: BasicPage
    {
        private IWebDriver driver;
        public CarsValidations(IWebDriver driver) : base(driver)
        {
            
        }


    }
}
