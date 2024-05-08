using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using PageObjectModel.Source.Pages;
using SeleniumExtras.PageObjects;
using System;
using PageObjectModel.Source.Pages;

namespace WebDriver_task_1__nunit_
{
    namespace PageObjectModel.Tests
    {
        public class HomeTests
        {
            private IWebDriver _driver;

            [SetUp]
            public void Setup()
            {

                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl("https://pastebin.com/");
            }


            [Test]

            public void PasteBinCreation()
            {
                PastebinPage pastebinPage = new PastebinPage(_driver);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                IWebElement parentElement = _driver.FindElement(By.ClassName("qc-cmp2-summary-buttons"));
                IWebElement secondChildElement = parentElement.FindElement(By.XPath("./*[2]"));
                secondChildElement.Click();
                
                pastebinPage.PastebinTextarea.SendKeys("Hello from WebDriver");

                pastebinPage.PasteExpiration.Click();
                _driver.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();

                pastebinPage.PastebinName.SendKeys("helloweb");
                pastebinPage.CreateBtn.Click();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                Assert.That(pastebinPage.SuccessPostElement.Displayed, Is.True);
            }

            [TearDown]
            public void Cleanup()
            {
                _driver.Quit();
            }
        }
    }
}