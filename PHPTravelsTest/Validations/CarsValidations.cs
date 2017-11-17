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
    public class CarsValidations
    {
        public static void ValidateAddedCar(CarsPage cars, string carName)
        {
            Assert.AreEqual(carName, cars.ValidateAddedCar(carName));
        }



    }
}
