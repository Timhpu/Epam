using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    [Obsolete]
    public class HomePage : GetTextXpath
    {
            IWebDriver driver;
            public HomePage(IWebDriver driver)
            {
                this.driver = driver;
                PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
            }

            [FindsBy(How = How.XPath, Using = "//a[contains(text(),'News')]")]
            private IWebElement newsLink;

            public void ClickNews()
            {
                newsLink = driver.FindElement(By.XPath(GetTextXPath("News", 2)));
                newsLink.Click();
            }

            public void GoToBBC()
            {
                driver.Navigate().GoToUrl("https://www.bbc.com/");
            }

            public void MaxWindow()
            {
                driver.Manage().Window.Maximize();
            }
        }
    }



