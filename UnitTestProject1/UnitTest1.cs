using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {//Task 1.1
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.Manage().Window.Maximize();
            //* driver.FindElement(By.XPath("//div[@id='orb-modules']")); Задаем xpath из html-code //* 
            driver.FindElement(By.XPath("//a[contains(text(),'News')]")).Click(); //Переход на указанный элемент
            Assert.AreEqual("'No chance of US deal' if Brexit hits Irish accord", driver.FindElement(By.XPath("(//*[@data-entityid='container-top-stories#1']//h3)[1]")).Text);
            driver.Quit();
        }
        [TestMethod]
        public void TestMethod2()//Task 1.2
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.FindElement(By.XPath("//*[@id='orb-nav-links']/ul/li[2]/a")).Click();
            driver.FindElements(By.XPath("//a[contains(text(),'News')]")).ToList();
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
            /*for (int i = 0; i < 5; i++)
                Assert.AreEqual(text[i], actualTitles[i].Text);*/

            driver.Quit();
        }
        [TestMethod]
        public void TestMethod3()//Task 1.3
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.FindElement(By.XPath("//*[@id='orb-nav-links']/ul/li[2]/a")).Click();//News
            string catalog = driver.FindElement(By.XPath("//*[@id='//div/div/div/div[1]/div/div/div[1]/ul/li[@class='nw-c-promo-meta']//a")).Text;
            driver.FindElement(By.Id("orb-search-q")).SendKeys(catalog);//find by id
            driver.FindElement(By.Id("orb-seatch-button")).Click();
            string title = driver.FindElement(By.CssSelector("#search-content>ol>li:nth-child(1)>article>div>h1>a")).Text;
            Assert.AreEqual("US & Canada", title);
            driver.Quit();
        }
        [TestMethod]
        public void TestMethod4()//Task 2.1 
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.lipsum.com/");
            //IWebElement justincase = driver.FindElement(By.Id("amount")).Click();
            IWebElement Amount = driver.FindElement(By.XPath("//*[@id='amount']"));
            Amount.Clear();
            Amount.SendKeys("141");
            driver.FindElement(By.XPath("//label[@for='bytes']")).Click();
            IWebElement Generate = driver.FindElement(By.XPath("//*[@id='generate']"));
            Generate.Click();
            string lipsumTxt = driver.FindElement(By.XPath("//div[@id='lipsum']/p")).Text;
            string lipsumTxtSub = lipsumTxt.Substring(0, 140);
            //Task 2.2
            driver.Navigate().GoToUrl("https://www.bbc.com");
            driver.FindElement(By.XPath("//a[contains(text(),'News')]")).Click();
            IWebElement navigation = driver.FindElement(By.XPath("//nav[@role='navigation']/ul/li[last()]"));
            navigation.Click();
            IWebElement haveYourSay = driver.FindElement(By.XPath("//a[@class='nw-o-link']/span[contains(text(),'Have Your Say')]"));
            haveYourSay.Click();
            driver.FindElement(By.XPath("//*[@id='topos-component']/div[4]/div/div[1]/div/div[1]/div/div[2]/div[1]")).Click();
            IWebElement userName = driver.FindElement(By.XPath("//input[@aria-label='Name']"));
            userName.SendKeys("Yaro");
            IWebElement userEmail = driver.FindElement(By.XPath("//input[@aria-label='Email address']"));
            userEmail.SendKeys("Yaro@gmail.com");
            IWebElement age = driver.FindElement(By.XPath("//input[@aria-label='Age']"));
            age.SendKeys("20");
            IWebElement postcode = driver.FindElement(By.XPath("//input[@aria-label='Postcode']"));
            postcode.SendKeys("03150");
            IWebElement chechbox = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            chechbox.Click();
            IWebElement textarea = driver.FindElement(By.XPath("//textarea[@aria-label='What questions would you like us to investigate?']"));
            textarea.SendKeys(lipsumTxtSub);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("D:/QA-C#/Automation/hello.png");
            driver.Quit();
        }
        [TestMethod]
        public void TestMethod5()//Task 2.3.1
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.lipsum.com/");
            //IWebElement justincase = driver.FindElement(By.Id("amount")).Click();
            IWebElement Amount = driver.FindElement(By.XPath("//*[@id='amount']"));
            Amount.Clear();
            Amount.SendKeys("141");
            driver.FindElement(By.XPath("//label[@for='bytes']")).Click();
            IWebElement Generate = driver.FindElement(By.XPath("//*[@id='generate']"));
            Generate.Click();
            string lipsumTxt = driver.FindElement(By.XPath("//div[@id='lipsum']/p")).Text;
            string lipsumTxtSub = lipsumTxt.Substring(0, 140); // Выполняется для того что бы елемент был скопирован в одном методе
            driver.Navigate().GoToUrl("https://www.bbc.com/");
            driver.FindElement(By.XPath("//a[contains(text(),'News')]")).Click();
            driver.FindElement(By.XPath("//span[@class='nw-c-nav__wide-morebutton-separator']/button/span[text()='More']")).Click();
            driver.FindElement(By.XPath("//span[text()='Have Your Say']")).Click();
            driver.FindElement(By.XPath("//*[@id='topos-component']/div[4]/div/div[1]/div/div[1]/div/div[2]/div[1]")).Click();
            IWebElement textArea = driver.FindElement(By.XPath("//div/textarea[@placeholder='What questions would you like us to investigate?']"));
            textArea.SendKeys(lipsumTxtSub);
            IWebElement name = driver.FindElement(By.XPath("//div/label/input[@placeholder='Name']"));
            name.SendKeys("Yaro");
            IWebElement email = driver.FindElement(By.XPath("//div/label/input[@placeholder='Email address']"));
            email.SendKeys("Yaro@gmail.com");
            IWebElement age = driver.FindElement(By.XPath("//div/label/input[@placeholder='Age']"));
            age.SendKeys("20");
            IWebElement postcode = driver.FindElement(By.XPath("//div/label/input[@placeholder='Postcode']"));
            postcode.SendKeys("03150");
            IWebElement chechbox = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            chechbox.Click();
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("D:/QA-C#/Automation/Hellodva.png");
            driver.Quit();
        }
        [TestMethod]
        public void TestMethod6()//Task 2.3.2
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com/news");
            driver.FindElement(By.XPath("//li[@class='orb-nav-newsdotcom']/a[text()='News']"));
            driver.FindElement(By.XPath("//span[@class='nw-c-nav__wide-morebutton-separator']/button/span[text()='More']")).Click();
            driver.FindElement(By.XPath("//span[text()='Have Your Say']")).Click();
            driver.FindElement(By.XPath("//*[@id='topos-component']/div[4]/div/div[1]/div/div[1]/div/div[2]/div[1]")).Click();
            IWebElement textArea = driver.FindElement(By.XPath("//div/textarea[@placeholder='What questions would you like us to investigate?']"));
            textArea.SendKeys("333");
            IWebElement email = driver.FindElement(By.XPath("//div/label/input[@placeholder='Email address']"));
            email.SendKeys("Yaro@gmail.com");
            IWebElement age = driver.FindElement(By.XPath("//div/label/input[@placeholder='Age']"));
            age.SendKeys("20");
            IWebElement postcode = driver.FindElement(By.XPath("//div/label/input[@placeholder='Postcode']"));
            postcode.SendKeys("03150");
            IWebElement chechbox = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            chechbox.Click();
            IWebElement submit = driver.FindElement(By.XPath("//div[@class='button-container']"));
            submit.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual(("Name can't be blank"), driver.FindElement(By.XPath("//div[@class='input-error-message']")).Text);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("D:/QA-C#/Automation/hellodvava.png");
            driver.Quit();
        }
        [TestMethod]
        public void TestMethod7() //Task 2.3.3
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com/news");
            driver.FindElement(By.XPath("//li[@class='orb-nav-newsdotcom']/a[text()='News']"));
            driver.FindElement(By.XPath("//span[@class='nw-c-nav__wide-morebutton-separator']/button/span[text()='More']")).Click();
            driver.FindElement(By.XPath("//span[text()='Have Your Say']")).Click();
            driver.FindElement(By.XPath("//*[@id='topos-component']/div[4]/div/div[1]/div/div[1]/div/div[2]/div[1]")).Click();
            IWebElement textArea = driver.FindElement(By.XPath("//div/textarea[@placeholder='What questions would you like us to investigate?']"));
            textArea.SendKeys("333");
            IWebElement name = driver.FindElement(By.XPath("//div/label/input[@placeholder='Name']"));
            name.SendKeys("Yaro");
            IWebElement age = driver.FindElement(By.XPath("//div/label/input[@placeholder='Age']"));
            age.SendKeys("20");
            IWebElement postcode = driver.FindElement(By.XPath("//div/label/input[@placeholder='Postcode']"));
            postcode.SendKeys("03150");
            IWebElement chechbox = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            chechbox.Click();
            IWebElement submit = driver.FindElement(By.XPath("//div[@class='button-container']"));
            submit.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual(("Email address can't be blank"), driver.FindElement(By.XPath("//div[@class='input-error-message']")).Text);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("D:/QA-C#/Automation/hellotri.png");
        }
    }
}
