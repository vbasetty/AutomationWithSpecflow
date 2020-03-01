using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace AutomationWithSpecflow
{
    [Binding]
    public class CheckingLoginButtonExistanceOnThePageSteps : IDisposable
    {
        private ChromeDriver driver;
        public CheckingLoginButtonExistanceOnThePageSteps () => driver = new ChromeDriver();
        [Given(@"I have navigated to UBS site")]
        public void GivenIHaveNavigatedToUBSSite()
        {
            driver.Navigate().GoToUrl("www.ubs.com");
            System.Threading.Thread.Sleep(1000);
        }
        
        [When(@"the Home page loads on the browser")]
        public void WhenTheHomePageLoadsOnTheBrowser()
        {
            Assert.IsTrue(driver.Title.ToUpper().Contains("UBS"));
        }
        
        [Then(@"the login In link appears on the Home page")]
        public void ThenTheLoginInLinkAppearsOnTheHomePage()
        {
            var loginButton = driver.FindElementByXPath("//span[contains(text(), 'UBS logins')]");
            loginButton.Click();
        }
        public void Dispose()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }
    }
}
