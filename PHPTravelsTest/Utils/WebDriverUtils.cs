using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PHPTravelsTest.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPTravelsTest.Utils
{
    static class WebDriverUtils
    {

        public static void WaitForElementToBeClickable(IWebDriver driver, IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

        public static void WaitForNoFoundElementToBeClickable(IWebDriver driver, IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

        public static void WaitForTextToBePresentInElement(IWebDriver driver, IWebElement webElement, string value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElement(webElement, value));
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

        public static Boolean WaitForInvisibilityOfElementLocated(IWebDriver driver, string Xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath)));
        }

        public static void WaitForElementExist(IWebDriver driver, string Xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Xpath)));
        }

        public static string GetElementText(IWebElement webelement)
        {
            string ElementTextValue = webelement.Text;
            return ElementTextValue;
        }

        public static string GetInputText(IWebElement webElement)
        {
            string ElementTextValue = webElement.GetAttribute("value");
            return ElementTextValue;
        }

        public static void WaitForElementHasText(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until<IWebElement>((d) => {
                IWebElement element = d.FindElement(By.XPath(".//input[@id='codeadd' and @placeholder='Coupon Code']"));
                if (element.GetAttribute("value") != "")
                {
                    return element;
                }

                return null;
            });

        }
    }
}
