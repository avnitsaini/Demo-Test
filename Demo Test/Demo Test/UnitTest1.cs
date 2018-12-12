using System;
using System.IO;
using DemoTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoTest
{
    [TestClass]
    public class DemoTestCase
    {
        private INavigation navigation;
        private ChromeDriver driver;
        private PageHelper pageHelper;
        private WebHelpers webHelpers;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver(Directory.GetCurrentDirectory());
            navigation = driver.Navigate();
            pageHelper = new PageHelper(driver);
            webHelpers = new WebHelpers(driver);
        }

        [TestMethod]
        public void HomePageTest()
        {
            //1. Open the browser, navigate to the website             
            pageHelper.OpenWebSite();
            webHelpers.WaitForPageToLoad();

            //2. Click Contact and verify the no. 0845 299 0900 is displayed
            pageHelper.ClickContact();
            webHelpers.WaitForPageToLoad();
            Assert.AreEqual(pageHelper.ContactNumberDisplayed(), "0845 299 0900");

            //3. Verify Oxford displayed under offices

            Assert.AreEqual(pageHelper.OfficeDisplayed("Oxford"), "Oxford");


            //4. Verify London displayed under offices
            Assert.AreEqual(pageHelper.OfficeDisplayed("London"), "London");

            
            driver.Close();
            Assert.IsTrue(Logger.GetFinalTestResult(), "Read log for more info.");
        }
    }
}
