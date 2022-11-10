using Dynamitey;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs_UI.Drivers
{
    public class BaseTest
    {
        public static IWebDriver driver;
       
        /// <summary>
        /// This method is used to setup the browser instance and setup the implicit wait for 30 Seconds.
        /// Therefore browser will hold for 30 seconds.
        /// </summary>
        /// <return>
        /// Void
        /// </return>
        /// 
        public void BrowserSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }       
       
    }
}
