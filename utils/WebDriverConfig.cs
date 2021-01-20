using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SGA.utils
{
    public class WebDriverConfig
    {
        ExtentReports reports = new ExtentReports();
        public static int test_number = 01;

        //Method where will initialize web driver and setup initial config.
        public IWebDriver WebDriverInitialConfig(IWebDriver driver, string baseUrl, ref ExtentTest test)
        {
            ExtentStart();
            
            test = reports.CreateTest("Login SGA - " + "Test " + test_number).Info("Test " + test_number + " Started.");
            test_number++;

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);

            test.Log(Status.Info, "Chrome Browser launched.");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(baseUrl);

            test.Log(Status.Info, "Navigating to the defined url.");

            return driver;
        }

        //Method to close the web driver.
        public void CloseWebDriver(IWebDriver driver)
        {
            try
            {
                driver.Close();
                ExtentClose();
            }
            catch (Exception e)
            {
                
                System.Console.WriteLine(e.Message);
            }
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {
            // Here is your folder where the html file will be generated.
            var htmlReporter = new ExtentV3HtmlReporter(@"");   
            reports.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            reports.Flush();
        }
    }
}