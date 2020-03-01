using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace AutomationWithSpecflow
{
    [Binding]
    public class ValidatingWhetherTheWebPageContainsTheDefinedTextSteps : IDisposable
    {
        private ChromeDriver driver;
        public ValidatingWhetherTheWebPageContainsTheDefinedTextSteps() => driver = new ChromeDriver();
        [Given(@"I have navigated to web page")]
        public void GivenIHaveNavigatedToWebPage()
        {
            driver.Navigate().GoToUrl("www.ubs.com");
            System.Threading.Thread.Sleep(1000);
        }

        [When(@"the Home page loads in the browser")]
        public void WhenTheHomePageLoadsInTheBrowser()
        {
            Assert.IsTrue(driver.Title.ToUpper().Contains("UBS"));
        }

        [Then(@"the defined text should be visible on the Home page")]
        public void ThenTheDefinedTextShouldBeVisibleOnTheHomePage()
        {
            WebElement bodyTag = driver.findElement(By.Xpath("//*[@id='main']/div[1]/div/a/div[1]/div/div/h2/span"));
            if (bodyTag.getText().contains("Future of Waste Part 1: Types, Sources and Impact")
                {

                Console.WriteLine("Expected Text is displayed");
            }
            else { 
                Console.WriteLine("Expected Text is not displayed"); 
            
            }
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
}
