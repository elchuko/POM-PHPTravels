using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using PHPTravelsTest.POM;
using PHPTravelsTest.Tests;

namespace PHPTravelsTest.Validations
{
    public static class CarsValidations
    {
        private static readonly log4net.ILog Logger = Utils.Logger.GetLoggerInstance();
        public static void ValidateAddedCar(CarsPage carsPage, string carName)
        {
            try
            {
                Logger.Info("Try to Assert if carName is the same than the Written");
                Assert.AreEqual(carName, carsPage.ValidateAddedCar(carName));
            }
            catch (Exception e)
            {
                Logger.Error("they are not the same");
                Console.WriteLine("Something went wrong");
                Assert.Fail();

            }


        }



    }
}
