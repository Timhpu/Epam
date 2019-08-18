using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using UnitTestProject1.BusinessLogic;
using UnitTestProject1.Pages;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2 { 


    static IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            NewsPage news = new NewsPage(driver);
            LoremIpsumPage lorem = new LoremIpsumPage(driver);
            BLLoremIpsum Bllorem = new BLLoremIpsum(driver);
            HaveYourSayPage yoursay = new HaveYourSayPage(driver);
            BLHaveYourSay Blyoursay = new BLHaveYourSay(driver);
            SearchResults afterSearch = new SearchResults(driver);

        [TestMethod]
        public void TestMethod1()
        {
            home.MaxWindow();
            home.GoToBBC();
            home.ClickNews();
            news.AreEqualMainArticleTitle("Trump targets legal migrants who get food aid");
        }

        [TestMethod]
        [Obsolete]
        public void TestMethod2()

        {
            news.AreEqualOtherTitles();
        }

        [TestMethod]
        public void TestMethod3()
        {
            news.Search();
            afterSearch.AreEqualFirstArticle("Dangerous heatwave starts hitting US and Canada");
        }


        [TestMethod]
        public void TestMethod4()
        {
            string text = Bllorem.LoremText(140);

            Dictionary<string, string> values = new Dictionary<string, string>(5);
            values.Add("Name", "Yaro");
            values.Add("Email address", "Yaro@gmail.com");
            values.Add("Age", "20");
            values.Add("Postcode", "03150");
            values.Add("What", text);

            Blyoursay.FillTheForm(values, true);

        }

        [TestMethod]
        public void TestMethod5()
        {
            string text = Bllorem.LoremText(141);

            Dictionary<string, string> values = new Dictionary<string, string>(5);
            values.Add("Name", "Yaro");
            values.Add("Email address", "Yaro@gmail.com");
            values.Add("Age", "20");
            values.Add("Postcode", "03150");
            values.Add("What", text);

            Blyoursay.FillTheForm(values, true);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string text = Bllorem.LoremText(140);

            Dictionary<string, string> values = new Dictionary<string, string>(5);
            values.Add("Name", "");
            values.Add("Email address", "Yaro@gmail.com");
            values.Add("Age", "20");
            values.Add("Postcode", "03150");
            values.Add("What", text);

            Blyoursay.FillTheForm(values, false);
        }

        [TestMethod]
        public void TestMethod7()
        {
            string text = Bllorem.LoremText(140);

            Dictionary<string, string> values = new Dictionary<string, string>(5);
            values.Add("Name", "Yaro");
            values.Add("Email address", "");
            values.Add("Age", "20");
            values.Add("Postcode", "03150");
            values.Add("What", text);
            Blyoursay.FillTheForm(values, false);
        }

        [TestMethod]
        public void Z_Quit()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }

 
}
