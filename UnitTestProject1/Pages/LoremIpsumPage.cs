using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [Obsolete]
    class LoremIpsumPage : GetTextXpath 
    {
        IWebDriver driver;
        public LoremIpsumPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }
        [FindsBy(How = How.XPath, Using = "//label[@for='bytes']")]
        internal IWebElement bytes;

        [FindsBy(How = How.XPath, Using = "//*[@id='amount']")]
        internal IWebElement amount;

        [FindsBy(How = How.XPath, Using = "//*[@id='generate']")]
        internal IWebElement generate;

        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']/p")]
        internal IWebElement lipsum;

        public string loremText;
    }
}