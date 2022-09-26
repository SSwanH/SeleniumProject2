using System;
using System.ComponentModel;
using System.Threading;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit.Sdk;

namespace SelentiumProject2
{
    public class Tests
    {
        private const string HomeUrl = "https://app.hireologyqa.com/users/sign_in";
        private const string JobsUrl = "https://app.hireologyqa.com/jobs";
        [Fact]
        [Trait("Category", "Smoke")]
        public void LoginToApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);

                string pageTitle = driver.Title;

                driver.FindElement(By.Id("user_username")).SendKeys("seleniumuser@test.com");
                driver.FindElement(By.Id("user_password")).SendKeys("Testing2022$$");
                driver.FindElement(By.Id("sign_in")).Click();
                Thread.Sleep(10000);


            }
        }
        [Fact]
        [Trait("Category", "Smoke")]
        public void VerifyJobsPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            
            
            Assert.Equal(JobsUrl, driver.Url);
            Thread.Sleep(3000);
            
        }
        [Fact]
        [Trait("Category", "Smoke")]
        public void LogoutOfApp()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.FindElement(By.Id("signout")).Click();
                Thread.Sleep(10000);
                Assert.Equal(HomeUrl, driver.Url);
            }
                
        }
    }
}