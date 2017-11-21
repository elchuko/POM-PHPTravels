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
        public static void ValidateAddedCar(CarsPage carsPage, string carName)
        {
            try
            {
                Assert.AreEqual(carName, carsPage.ValidateAddedCar(carName));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
        }



    }
}
