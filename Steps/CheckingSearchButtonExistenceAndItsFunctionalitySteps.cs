using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace AutomationWithSpecflow
{
    [Binding]
    public class CheckingSearchButtonExistenceAndItsFunctionalitySteps : IDisposable
    {
        private ChromeDriver driver;
        private object searchInputBox;
        private String searchKeyword;
        private IWebElement searchResults;

        public CheckingSearchButtonExistenceAndItsFunctionalitySteps() => driver = new ChromeDriver();

        [Given(@"I have navigated to UBS")]
        public void GivenIHaveNavigatedToUBS()
        {
            driver.Navigate().GoToUrl("www.ubs.com");
            System.Threading.Thread.Sleep(1000);
        }

        [Given(@"I have clicked on the search button")]
        public void GivenIHaveClickedOnTheSearchButton()
        {
            var searchButton = driver.FindElementByXPath("//*[@id='metanav']/div[2]/button");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='metanav']/div[2]/button")));
            searchButton.Click();
        }

        [When(@"the Header search opens")]
        public void WhenTheHeaderSearchOpens()
        {
            this.searchInputBox = driver.FindElementByXPath("//*[@id='pagesearchfield']");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='pagesearchfield']")));
        }

        [When(@"I have entered the (.*) string")]
        public void WhenIHaveEnteredTheString(String searchString)
        {
            this.searchKeyword = searchString.ToLower();
            this.searchInputBox.SendKeys(searchKeyword);
        }

        [When(@"I have clicked on search button again")]
        public void WhenIHaveClickedOnSearchButtonAgain()
        {
            var searchButton = driver.FindElementByXPath("//*[@id='headerSearch']/form/button[2]");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='headerSearch']/form/button[2]")));
            searchButton.Click();
        }

        [Then(@"the associated page displays")]
        public void ThenTheAssociatedPageDisplays()
        {
            searchResults = driver.FindElementByXPath("//*[@id='pagesearchfield']");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='searchresults__icon']")));
            Assert.IsTrue(driver.Title.ToLower().Contains(searchKeyword));
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
