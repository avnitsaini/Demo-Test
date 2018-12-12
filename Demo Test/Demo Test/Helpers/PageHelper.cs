using DemoTest.Enums;
using DemoTest.Extensions;
using DemoTest.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest.Helpers
{
    public class PageHelper
    {
        private ChromeDriver driver;
        private OpenQA.Selenium.INavigation navigation;
        private string sitekitLink = "https://www.sitekit.net";        
        private WebHelpers webHelper;


        public PageHelper(ChromeDriver driver)
        {
            this.driver = driver;
            navigation = driver.Navigate();
            webHelper = new WebHelpers(driver);
        }

        public void OpenWebSite()
        {
            navigation.GoToUrl(sitekitLink);
            driver.Manage().Window.Maximize();           
        }


        public void ClickContact()
        {
            driver.FindElementByCssSelector(@"a[href='/#contact']").Click();
        }

        public string ContactNumberDisplayed()
        {
            String ContactNumberDisplayed = driver.FindElementByClassName("column two").Text;
            return ContactNumberDisplayed;
        }

        public bool OfficeDisplayed(string OfficeLocation)
        {
            IWebElement SitekitOffices = driver.FindElementByClassName("our-offices collapsibles active");
            IList<IWebElement> ListOfOffices = SitekitOffices.FindElements(By.TagName("a"));
            int NoOfOffices = ListOfOffices.Count;
            for (int j=0;j<= NoOfOffices;j++)
            {
                if (ListOfOffices[j].Text == "OfficeLocation")
                {
                    return true;
                }
            }
            return false;
            
        }      
    }
}
