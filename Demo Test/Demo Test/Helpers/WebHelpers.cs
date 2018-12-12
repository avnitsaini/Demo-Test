using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoTest.Helpers
{
    public class WebHelpers
    {
        private ChromeDriver driver;

        public WebHelpers(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForPageToLoad()
        {
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            //driver.ExecuteScript("window.focus();");
            //string pageLoadStatus;
            //do
            //{
            //    pageLoadStatus = (string)driver.ExecuteScript("return document.readyState");
            //} while (!pageLoadStatus.Equals("complete"));
            Thread.Sleep(2000);
        }

        public IWebElement WaitElement(By by, int timeOutSec = 10)
        {
            var counter = timeOutSec * 5;
            do
            {
                Thread.Sleep(200);
                var result = driver.FindElements(by);
                if (result.Any() && result.Count != 0)
                {
                    return result.First();
                }
                counter--;
            } while (counter > 0);

            return null;
        }

        public void ScrollIntoView(OpenQA.Selenium.IWebElement element)
        {
            driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
