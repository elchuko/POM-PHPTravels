using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PHPTravelsTest.Utils
{
    public static class CleanUpClass
    {
        private static readonly log4net.ILog Logger = Utils.Logger.GetLoggerInstance();
        public static void CloseAndClean(IWebDriver driver)
        {
            Logger.Info("driver.Close");
            driver.Close();
            Logger.Info("driver.Quit");
            driver.Quit();
        }
    }
}
