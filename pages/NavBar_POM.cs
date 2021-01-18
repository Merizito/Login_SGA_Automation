using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace SGA.pages
{
    public class NavBar_POM : Pages
    {
        public WebDriverWait wait;

        public NavBar_POM(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#divAreaUsuario > ul")]
        public IWebElement userNavBar { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > form > table > tbody > tr:nth-child(1) > td > header > font > nav:nth-child(2) > aside > section > div > ul")]
        public IWebElement menuNavBar { get; set; }
    }
}