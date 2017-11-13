﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPTravelsTest.Utils
{
    class WebDriverUtils
    {
        private WebDriverUtils()
        {
            //This constructor is empty and private, to avoid to be used due to is only for utilities tools.
        }

        public static void WaitForElementToBeClickable(IWebDriver driver, IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

        public static void WaitForTextToBePresentInElement(IWebDriver driver, IWebElement webElement, string value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElement(webElement,value));
        }

        public static void WaitForElementToBeVisible(IWebDriver driver, string Xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Xpath)));
        }

        public static void WaitForAlertIsPresent(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
        }

    }
}
