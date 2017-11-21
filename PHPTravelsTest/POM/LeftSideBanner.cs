using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PHPTravelsTest.Utils;

namespace PHPTravelsTest
{
    public class LeftSideBanner: BasicPage
    {
        private IWebDriver driver;

        private static readonly log4net.ILog Logger = Utils.Logger.GetLoggerInstance();
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
            Logger.Info("Click on My profile Arrow");
            WebDriverUtils.WaitForElementToBeClickable(driver, myProfileArrow);
            //wait.Until(ExpectedConditions.ElementToBeClickable(myProfileArrow));
            myProfileArrow.Click();
            Logger.Info("Click on My Profile");
            myProfile.Click();
        }

        public void GoToCouponsPage()
        {
            WebDriverUtils.WaitForElementToBeClickable(driver,CouponsPage);
            Logger.Info("Click on Coupons Menu");
            CouponsPage.Click();
        }

        public void GoToCarsMenu()
        {
            WebDriverUtils.WaitForElementToBeVisible(driver, "//*[@id='social-sidebar-menu']/li[6]/a");
            Logger.Info("Click on Cars menu");
            menuCars.Click();

        }

        public void GoToCarsInsideCarsMenu()
        {
            GoToCarsMenu();
            WebDriverUtils.WaitForElementToBeVisible(driver, "//*[@id='Cars']/li[1]/a");
            Logger.Info("Click on Cars/Cars");
            carsInsideCars.Click();
        }

        public void GoToExtrasInsideCarsMenu()
        {
            GoToCarsMenu();
            Logger.Info("Click on Cars/Extras");
            extrasInsideCars.Click();
        }

        public void GoToCarSettingsInsideCarsMenu()
        {
            GoToCarsMenu();
            Logger.Info("Click on Cars/Settings");
            carsSettingsInsideCars.Click();
        }



    }
}
