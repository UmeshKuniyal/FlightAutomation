using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FlightAutomation.CommonMethods
{
    public  class Helper
    {
        public static IWebElement GetElementByXpath(IWebDriver driver, string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, IWebElement> waitForElement = new Func<IWebDriver, IWebElement>((IWebDriver Web) => {
                HighlightControl(Web.FindElement(By.XPath(xpath)), driver);
                return Web.FindElement(By.XPath(xpath));
            });
            return wait.Until(waitForElement);
        }

        public static IList<IWebElement> GetElementsByXpath(IWebDriver driver, string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, IList<IWebElement>> waitForElement = new Func<IWebDriver, IList<IWebElement>>((IWebDriver Web) => {
                return Web.FindElements(By.XPath(xpath));
            });
            return wait.Until(waitForElement);
        }

        public static void HighlightControl(IWebElement element, IWebDriver browserDriver)
        {
            var javaScriptDriver = (IJavaScriptExecutor)browserDriver;
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 3px; border-style: solid; border-color: green"";";
            javaScriptDriver.ExecuteScript(highlightJavascript, new object[] { element });
            Thread.Sleep(1000);
            highlightJavascript = @"arguments[0].style.cssText = ""border-width: 0px; border-style: solid; border-color: green"";";
            javaScriptDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }


    }
}
