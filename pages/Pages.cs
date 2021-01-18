using System.Collections.Generic;
using OpenQA.Selenium;

namespace SGA.pages
{
    public class Pages
    {
        public IWebDriver driver;
        public Pages(IWebDriver driver)
        {
            this.driver = driver;
        }

        public List<IWebElement> CreateListElements(IWebElement fatherElement, string ElementTagName)
        {
            List<IWebElement> listOfElements = new List<IWebElement>();

            foreach (IWebElement element in fatherElement.FindElements(By.TagName(ElementTagName)))
            {
                listOfElements.Add(element);
            }

            return listOfElements;
        }

        public void ChooseOneAndSelect(string myChoice, List<IWebElement> elementsList)
        {
            foreach (IWebElement element  in elementsList)
            {
                if (element.Text == myChoice)
                {
                    element.Click();
                    //System.Console.WriteLine(element.Text);
                }
            }
        }

    }
}