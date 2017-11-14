using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PHPTravelsTest.Utils;

namespace PHPTravelsTest
{
    public class LeftSideBanner: BasicPage
    {
        private IWebDriver driver;
        //private WebDriverWait wait;
        //constructor
        public LeftSideBanner(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
           // wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='social-sidebar-menu']/li[6]/a")]
        private IWebElement menuCars;

        [FindsBy(How = How.XPath, Using = "html/body/div[2]/header/nav/div[3]/ul[2]/li[2]/ul/li[1]/a")]
        private IWebElement myProfile;

        [FindsBy(How = How.XPath, Using = "html/body/div[2]/header/nav/div[3]/ul[2]/li[2]/a/i")]
        private IWebElement myProfileArrow;

        [FindsBy(How = How.XPath, Using = ".//ul[@id='social-sidebar-menu']/li[12]/a/span")]
        private IWebElement CouponsPage;

        [FindsBy(How = How.XPath, Using = "//*[@id='Cars']/li[1]/a")]
        private IWebElement carsInsideCars;

        [FindsBy(How = How.XPath, Using = "//*[@id='Cars']/li[3]/a")]
        private IWebElement extrasInsideCars;

        [FindsBy(How = How.XPath, Using = "//*[@id='Cars']/li[4]/a")]
        private IWebElement carsSettingsInsideCars;

        public void GoToMyProfile()
        {
            System.Threading.Thread.Sleep(2000);
            WebDriverUtils.WaitForElementToBeClickable(driver, myProfileArrow);
            //wait.Until(ExpectedConditions.ElementToBeClickable(myProfileArrow));
            myProfileArrow.Click();
            myProfile.Click();
        }

        public void GoToCouponsPage()
        {
            WebDriverUtils.WaitForElementToBeClickable(driver,CouponsPage);
            //wait.Until(ExpectedConditions.ElementToBeClickable(CouponsPage));
            CouponsPage.Click();
        }

        public void GoToCarsMenu()
        {
            WebDriverUtils.WaitForElementToBeVisible(driver, "//*[@id='social-sidebar-menu']/li[6]/a");
            menuCars.Click();

        }

        public void GoToCarsInsideCarsMenu()
        {
            GoToCarsMenu();
            WebDriverUtils.WaitForElementToBeVisible(driver, "//*[@id='Cars']/li[1]/a");
            carsInsideCars.Click();
        }

        public void GoToExtrasInsideCarsMenu()
        {
            GoToCarsMenu();
            
            extrasInsideCars.Click();
        }

        public void GoToCarSettingsInsideCarsMenu()
        {
            GoToCarsMenu();
            
            carsSettingsInsideCars.Click();
        }



    }
}
