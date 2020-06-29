using FlightAutomation.CommonMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace FlightAutomation
{
    [TestFixture]
    public class Flight
    {
        IWebDriver browserDriver;
        Report rep;
        public static AventStack.ExtentReports.ExtentReports extent;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            rep = new Report();
            //Report.extent = new AventStack.ExtentReports.ExtentReports();
            rep.StartReport();
        }

        [SetUp]
        public void SetUp()
        {
            browserDriver = new FirefoxDriver();
            Report.test = Report.extent.CreateTest(NUnit.Framework.TestContext.CurrentContext.Test.MethodName);
            Report.test.Log(Status.Info, "Test case starts");

            browserDriver.Navigate().GoToUrl(Consants.websiteUrl);
            browserDriver.Manage().Window.Maximize();
            browserDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Test]
        public void FlightTest()
        {
            Helper.GetElementByXpath(browserDriver, ObjectRepository.flightButton).Click();
            Helper.GetElementByXpath(browserDriver, ObjectRepository.roundTripLabel).Click();
            Helper.GetElementByXpath(browserDriver, ObjectRepository.spanEconomy).Click();
            Helper.GetElementByXpath(browserDriver, ObjectRepository.businessClass).Click();
            Helper.GetElementByXpath(browserDriver, ObjectRepository.spanNYC).Click();
            IWebElement fromDestination = Helper.GetElementByXpath(browserDriver, ObjectRepository.dynamiclistItem);
            fromDestination.SendKeys(Consants.destinationDelhi);
            Helper.GetElementByXpath(browserDriver, ObjectRepository.divDelhi).Click();
            Helper.GetElementByXpath(browserDriver, ObjectRepository.spanMIA).Click();

            IJavaScriptExecutor executor = (IJavaScriptExecutor)browserDriver;


            IWebElement toDestination = Helper.GetElementByXpath(browserDriver, ObjectRepository.dynamiclistItem);
            toDestination.SendKeys(Consants.destinationBangalore);
            Helper.GetElementByXpath(browserDriver, ObjectRepository.divBangalore).Click();
            Helper.GetElementByXpath(browserDriver, ObjectRepository.divFlightsDateStart).Click();
            IWebElement departDate = Helper.GetElementByXpath(browserDriver, ObjectRepository.fromDateXpath);
            if (departDate != null)
                departDate.Click();
            IWebElement returnDate = Helper.GetElementByXpath(browserDriver, ObjectRepository.returnDateXpath);
            if (returnDate != null)
                returnDate.Click();

            //adding adult
            var adult = Helper.GetElementByXpath(browserDriver, ObjectRepository.buttonAdult);
            adult.Click();

            //adding  child
            var child = Helper.GetElementByXpath(browserDriver, ObjectRepository.buttonChild);
            child.Click();

            //adding infant
            var infant = Helper.GetElementByXpath(browserDriver, ObjectRepository.buttonInfant);
            infant.Click();

            Helper.GetElementByXpath(browserDriver, ObjectRepository.buttonSearch).Click();


            var searchlist = Helper.GetElementsByXpath(browserDriver, ObjectRepository.listSearch);
            if (searchlist.Count > 0)
                Console.WriteLine("Total {0} flights found", searchlist.Count);
            else
            {
                Console.WriteLine("No Flights found");
            }

        }

        [Test]
        [TestCaseSource(typeof(UI_ValidationTestSource), "UiValidation")]
        public void ValidateUIControls(string element, string elementXpath)
        {
            Assert.That(CommonMethods.Helper.GetElementByXpath(browserDriver, elementXpath)!=null);
        }
           

        [TearDown]
        public void TearDown()
        {
            browserDriver.Close();
        }

        [OneTimeTearDown]
        public void OneTimesTearDown()
        {
            rep.CloseReport(browserDriver, Report.test, true);
        }
    }
}


