using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PHPTravelsTest.POM
{
    class SettingsCars: BasicPage
    {
        private IWebDriver driver;

        private static readonly log4net.ILog Logger = Utils.Logger.GetLoggerInstance();

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/form/button")]
        private IWebElement add;

        [FindsBy(How = How.XPath, Using = "//*[@id='GENERAL']/div[3]/div/input")]
        private IWebElement carNameTxtbox;

        public SettingsCars(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }



    }
}
