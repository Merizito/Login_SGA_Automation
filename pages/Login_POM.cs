using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using AventStack.ExtentReports;
using SGA.utils;

namespace SGA.pages
{
    public class Login_POM : Pages
    {
        public WebDriverWait wait;
        public WebDriverConfig extentinitialize;
        public Login_POM(IWebDriver driver) : base(driver)
        {
            //extentinitialize = new WebDriverConfig();
            //extentinitialize.ExtentStart(reports);
            
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            PageFactory.InitElements(driver, this);
        }

        //Tentar enxugar esse trecho.
        [FindsBy(How = How.Name, Using = "S48_")]
        [CacheLookup]
        public IWebElement login_input { get; set; }



        [FindsBy(How = How.Name, Using = "S62_")]
        [CacheLookup]
        public IWebElement pwd_input { get; set; }



        [FindsBy(How = How.Name, Using = "S76_")]
        [CacheLookup]
        public IWebElement origin_btn { get; set; }



        [FindsBy(How = How.Name, Using = "S122_")]
        [CacheLookup]
        public IWebElement login_btn { get; set; }



        [FindsBy(How = How.CssSelector, Using = "body > form > center > table > tbody > tr:nth-child(2) > td:nth-child(2) > p > table > tbody > tr:nth-child(1) > td > h1")]
        public IWebElement sga_logo { get; set; }


        public void DoLogin(string login, string password, string origin)
        {
            string elementTagName = "option";

            login_input.Clear();
            login_input.SendKeys(login);

            pwd_input.Clear();
            pwd_input.SendKeys(password);

            List<IWebElement> list = CreateListElements(origin_btn, elementTagName);
            ChooseOneAndSelect(origin, list);
            login_btn.Click();
        }

        public void DoLogin()
        {
            string loginInputTest = "";
            string pwdInputTest = "";
            string origin = "Graduação";
            string elementTagName = "option";

            login_input.Clear();
            login_input.SendKeys(loginInputTest);

            pwd_input.Clear();
            pwd_input.SendKeys(pwdInputTest);

            List<IWebElement>list = CreateListElements(origin_btn, elementTagName);
            ChooseOneAndSelect(origin, list);

            login_btn.Click();

        }
    }
}