using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace SGA.pages
{
    public class HomePage_POM : Pages
    {
        public WebDriverWait wait;
        public HomePage_POM(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#listaturmas > font > div > h2")]
        public IWebElement disciplines { get; set; }
    }
}