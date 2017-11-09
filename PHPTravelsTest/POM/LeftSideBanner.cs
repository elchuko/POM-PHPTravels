using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PHPTravelsTest
{
    public class LeftSideBanner: BasicPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        //constructor
        public LeftSideBanner(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='social-sidebar-menu']/li[6]/a")]
        private IWebElement dropdownCars;

        [FindsBy(How = How.XPath, Using = "//*[@id='Cars']/li[1]/a")]
        private IWebElement menuCars;

        [FindsBy(How = How.XPath, Using = "html/body/div[2]/header/nav/div[3]/ul[2]/li[2]/ul/li[1]/a")]
        private IWebElement myProfile;

        [FindsBy(How = How.XPath, Using = "html/body/div[2]/header/nav/div[3]/ul[2]/li[2]/a/i")]
        private IWebElement myProfileArrow;

        [FindsBy(How = How.XPath, Using = "//*[@id='social-sidebar-menu']/li[12]/a/span")]
        private IWebElement CouponsPage;

        public void GoToMyProfile()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(myProfileArrow));
            myProfileArrow.Click();
            myProfile.Click();
        }

        public void GoToCouponsPage()
        { 
            wait.Until(ExpectedConditions.ElementToBeClickable(CouponsPage));
            CouponsPage.Click();
        }

    }
}
