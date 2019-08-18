using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.BusinessLogic
{
    [Obsolete]
    class BLLoremIpsum : LoremIpsumPage
    {
        IWebDriver driver;
        public BLLoremIpsum(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        public string LoremText(int number)
        {
            string Number = (number * 2).ToString();
            driver.Navigate().GoToUrl("https://www.lipsum.com/");
            LoremIpsumPage lorem = new LoremIpsumPage(driver);
            lorem.bytes.Click();
            lorem.amount.Clear();
            lorem.amount.SendKeys(Number);
            lorem.generate.Click();

            lorem.loremText = lorem.lipsum.Text;
            return lorem.loremText;
        }

    }
}