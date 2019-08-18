using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Pages;

namespace UnitTestProject1.BusinessLogic
{

    class BLHaveYourSay : GetTextXpath 
    {
        IWebDriver driver;
        public BLHaveYourSay(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void FillTheForm(Dictionary<string, string> values, bool screenShot)
        {
            HaveYourSayPage haveyoursay = new HaveYourSayPage(driver);

            driver.Navigate().GoToUrl("https://www.bbc.com/");
            driver.FindElement(By.XPath(GetTextXPath("News", 2))).Click();
            driver.FindElement(By.XPath("//nav[@role='navigation']/ul/li[last()]")).Click();
            driver.FindElement(By.XPath("//a[@class='nw-o-link']/span[contains(text(),'Have Your Say')]")).Click();




            haveyoursay.questionToBBC.Click();
            haveyoursay.userName.SendKeys(values["Name"]);
            haveyoursay.userEmail.SendKeys(values["Email address"]);
            haveyoursay.age.SendKeys(values["Age"]);
            haveyoursay.postcode.SendKeys(values["Postcode"]);
            haveyoursay.daily.Click();
            haveyoursay.textarea.SendKeys(values["What"]);

            if (screenShot == true)
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("D:/QA-C#/Automation/hello.png");
            else
            {
                haveyoursay.submit.Click();
                foreach (KeyValuePair<string, string> value in values)
                {
                    if (value.Value == "" && value.Key == "Name")
                    {
                        if (!haveyoursay.inputENT.Displayed)
                            throw new Exception();
                    }
                    if (value.Value == "" && value.Key == "Email address")
                    {
                        if (!haveyoursay.inputEET.Displayed)
                            throw new Exception();
                    }
                }
            }
        }