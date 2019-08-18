using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support;
using System.Collections.Generic;


namespace UnitTestProject1
{
    [Obsolete]
    public class NewsPage : GetTextXpath
    {
        IWebDriver driver;
        public NewsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.XPath, Using = "(//a[contains(text(),'News')")]//News
        internal IWebElement newsLink;

        [FindsBy(How = How.XPath, Using = "(//*[@data-entityid='container-top-stories#1']//h3)[1]")]//#1 News Story
        internal IWebElement mainArticle;

        [FindsBy(How = How.XPath, Using = "//a[@class='gs-c-section-link gs-c-section-link--truncate nw-c-section-link nw-o-link nw-o-link--no-visited-state']/span")]//Find Element kind of ASia or USA
        internal IWebElement category;

        [FindsBy(How = How.XPath, Using = "//*[@id='orb-search-q']")]//searching
        internal IWebElement searchField;

        [FindsBy(How = How.XPath, Using = "//*[@id='orb-search-button']")]//button to click
        internal IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//nav[@role='navigation']/ul/li[last()]")]
        internal IWebElement navigation;

        [FindsBy(How = How.XPath, Using = "//a[@class='nw-o-link']/span[contains(text(),'Have Your Say')]")]
        internal IWebElement haveYourSay;

        public void AreEqualMainArticleTitle(string hardCoded)
        {
            Assert.AreEqual(hardCoded, mainArticle.Text);
        }

        internal void AreEqualOtherTitles()
        {
            throw new NotImplementedException();
        }

        public void AreEqualoffivetxt()
        {
            List<String> text = new List<String>
            { "Are the markets signalling a recession is due?",
                "China labels HK protests as 'near terrorism'",
                "Epstein accuser sues his estate and staff",
                "Is the bystander effect a myth?",
                "ASAP Rocky found guilty of assault"};

            foreach (string str in text)
            {
                driver.FindElement(By.XPath($"//h3[text()=\"{str}\"]"));
            }
        }

        public void Search()
        {
            searchField.SendKeys(category.Text);
            searchButton.Click();
        }

        public void MoreDropdownClick()
        {
            navigation.Click();
        }

        public void HaveYourSayClick()
        {
            haveYourSay.Click();
        }
    }
}

