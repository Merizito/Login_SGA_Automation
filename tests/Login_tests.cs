using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SGA.utils;
using SGA.pages;
using AventStack.ExtentReports;

namespace SGA.tests
{
    [TestFixture]
    public class Login_tests : WebDriverConfig
    {
        //Variables
        IWebDriver driver;
        Login_POM login;
        HomePage_POM homePage;
        WebDriverWait wait;
        ExtentTest test;
        bool test_result = false;

        //Login Variables
        string user = "", password = "", origin = "Graduação";

        [SetUp]
        public void SetupChrome()
        {
            driver = WebDriverInitialConfig(driver, "https://www.sistemas.pucminas.br/sgaaluno4/SilverStream/Pages/pgAln_LoginSSL.html", ref test);
        }

        [Test]
        public void T01_VerifyElementsOnScreen() //This test will verify if all elements are displayed on the screen.
        {
            try
            {
                login = new Login_POM(driver);

                Assert.That(driver.Title, Is.EqualTo("SGA - Aluno"));
                Assert.IsTrue(login.login_input.Displayed);
                Assert.IsTrue(login.pwd_input.Displayed);
                Assert.IsTrue(login.origin_btn.Displayed);
                Assert.IsTrue(login.login_btn.Displayed);
                test.Log(Status.Info, "Elements has been displayed.");


                test.Log(Status.Pass, "Test Passed.");
            }
            catch (AssertionException e)
            {
                test.Log(Status.Fail, "Test Failed.");
                System.Console.WriteLine(e.Message);
            }
        }

        [Test]
        public void T02_LoginInHappyWay() //This test will try to login on the happy way.
        {
            try
            {
                //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                login = new Login_POM(driver);
                login.DoLogin(user, password, origin);

                //wait.Until(driver => driver.FindElement(By.CssSelector("#listaturmas > font > div > h2")));

                homePage = new HomePage_POM(driver);
                test_result = (homePage.disciplines.Text == "Minhas Disciplinas");

                if(test_result == true)
                    test.Log(Status.Info, "Succesfully Logged in.");
                
                Assert.That(driver.Title, Is.EqualTo("SGA - Página Inicial"));
                Assert.IsTrue(test_result);

                test.Log(Status.Pass, "Test Passed.");
            }
            catch (AssertionException e)
            {
                test.Log(Status.Fail, "Test Failed.");
                System.Console.WriteLine(e.Message);
            }
        }

        [Test]
        public void T03_TryLoginWithWrongUser() //This test will try to login with wrong user id.
        {
            try
            {
                login = new Login_POM(driver);
                login.DoLogin("5", password, origin);

                test_result = (login.driver.SwitchTo().Alert().Text.StartsWith("Acesso negado."));
                Assert.IsTrue(test_result);

                if(test_result == true)
                    test.Log(Status.Info, "As expected, login failed.");

                login.driver.SwitchTo().Alert().Dismiss(); //Close the Alert box before back to main frame.
                login.driver.SwitchTo().ParentFrame();

                test.Log(Status.Pass, "Test Passed.");
            }
            catch (AssertionException e)
            {
                test.Log(Status.Fail, "Test Failed.");
                System.Console.WriteLine(e);
            }
        }

        [Test]
        public void T04_TryLoginWithWrongPassword() //This test will try to login with wrong password
        {
            try
            {
                login = new Login_POM(driver);
                login.DoLogin(user, "abc123", origin);

                test_result = (driver.SwitchTo().Alert().Text.StartsWith("Acesso negado."));
                Assert.IsTrue(test_result);

                if(test_result == true)
                    test.Log(Status.Info, "As expected, login failed.");

                login.driver.SwitchTo().Alert().Dismiss(); //Close the Alert box before back to main frame.
                login.driver.SwitchTo().ParentFrame();
                
                test.Log(Status.Pass, "Test Passed.");
            }
            catch (AssertionException e)
            {   
                test.Log(Status.Fail, "Test Failed.");
                System.Console.WriteLine(e.Message);
            }
        }

        [Test]
        public void T05_TryLoginWithWrongOrigin()
        {
            try
            {
                login = new Login_POM(driver);
                login.DoLogin(user, password, "Funcionário");

                test_result = (login.driver.SwitchTo().Alert().Text.StartsWith("Acesso negado."));
                Assert.IsTrue(test_result);

                if(test_result == true)
                    test.Log(Status.Info, "As expected, login failed.");

                login.driver.SwitchTo().Alert().Dismiss(); //Close the Alert box before back to main frame.
                login.driver.SwitchTo().ParentFrame();

                test.Log(Status.Pass, "Test Passed.");
            }
            catch (AssertionException e)
            {
                test.Log(Status.Fail, "Test Failed.");
                System.Console.WriteLine(e.Message);
            }
        }

        [TearDown]
        public void CloseChrome()
        {
            CloseWebDriver(driver);
        }
    }
}