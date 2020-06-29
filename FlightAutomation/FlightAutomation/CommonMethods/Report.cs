using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightAutomation.CommonMethods
{
    public class Report
    {
        public static AventStack.ExtentReports.ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest test;
        public static string pathReflection = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        public static string actualPath = pathReflection.Substring(0, pathReflection.LastIndexOf("bin"));
        public static string projectPath = new Uri(actualPath).LocalPath;
        public static string reportPath;
      
        public void StartReport()
        {
            extent = new AventStack.ExtentReports.ExtentReports();
            reportPath = projectPath + @"Reports" + @"\";
            htmlReporter = new ExtentHtmlReporter(reportPath);

            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.DocumentTitle = "Test Repoprt | App Test";
            htmlReporter.Config.ReportName = "Test Repoprt | App Test";
            extent.AttachReporter(htmlReporter);
        }

        public void CloseReport(IWebDriver driver, ExtentTest test, bool screenshot = false)
        {
            //StackTrace details for failed Testcases
            var status = NUnit.Framework.TestContext.CurrentContext.Result.Outcome.Status;
            var message = NUnit.Framework.TestContext.CurrentContext.Result.Message;
            var stackTrace = "<pre>" + NUnit.Framework.TestContext.CurrentContext.Result.StackTrace + "</pre>";
            if (status == TestStatus.Failed)
            {
                if (screenshot == true)
                {
                    string screenShotPath = Capture(driver, "ScreenShotName");
                    test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(screenShotPath));
                }
                test.Log(Status.Fail, stackTrace + " : " + message);
                extent.Flush();
            }
            else if (status == TestStatus.Skipped)
            {
                //test.Log(Status.Info, "Test case Skipped");
                test.Log(Status.Skip, message);
                extent.Flush();
            }
            else if (status == TestStatus.Passed)
            {
                test.Log(Status.Info, "Test case passed");
                test.Log(Status.Pass, message);
                extent.Flush();
            }

        }

        public string Capture(IWebDriver driver, string screenShotName)
        {
            Random rand = new Random();
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports/" + @"ErrorScreenshots_" + rand.Next().ToString() + screenShotName + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }



    }
}
