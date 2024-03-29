﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using PHPTravelsTest.POM;
using PHPTravelsTest.Utils;

namespace PHPTravelsTest
{
    class DashBoard: BasicPage
    {
        private IWebDriver driver;

        private static readonly log4net.ILog Logger = Utils.Logger.GetLoggerInstance();

        public DashBoard(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void goMyProfile()
        {
            Logger.Info("Go to My Profile");
            LeftSideBanner banner = new LeftSideBanner(driver);
            banner.GoToMyProfile();
            System.Threading.Thread.Sleep(3000);
        }

        public CouponsPage goToCouponsPage()
        {
            Logger.Info("Go To CouponsPage");
            LeftSideBanner banner = new LeftSideBanner(driver);
            banner.GoToCouponsPage();

            return new CouponsPage(driver);
        }

        public void GoCarsSubMenu()
        {
            Logger.Info("Go to Cars submenu");
            LeftSideBanner banner = new LeftSideBanner(driver);
            banner.GoToCarsInsideCarsMenu();
            Thread.Sleep(1000);

        }

        public void GoExtrasSubMenu()
        {
            Logger.Info("Go to Extras SubMenu");
            LeftSideBanner banner = new LeftSideBanner(driver);
            banner.GoToExtrasInsideCarsMenu();
            Thread.Sleep(1000);
        }

        public void GoSettingsSubMenu()
        {
            Logger.Info("Go to Car Settings");
            LeftSideBanner banner = new LeftSideBanner(driver);
            banner.GoToCarSettingsInsideCarsMenu();
            Thread.Sleep(1000);
        }
    }
}
