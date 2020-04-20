using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace BS_Specflow
{
    // Google Steps
    [Binding]
    public class SingleSteps
    {
        IWebDriver driver;
        public SingleSteps()
        {
            var caps = new DesiredCapabilities();

            caps.SetCapability("browser", "iPhone");
            caps.SetCapability("device", "iPhone 8 Plus");
            caps.SetCapability("realMobile", "true");
            caps.SetCapability("os_version", "11");
            caps.SetCapability("browserstack.user", "<BROWSERSTACK_USERNAME>");
            caps.SetCapability("browserstack.key", "<BROWSERSTACK_ACCCESS_KEY>");
            caps.SetCapability("name", "single");
            caps.SetCapability("build", "specflow");
            driver = new RemoteWebDriver(
            new Uri("http://hub-cloud.browserstack.com/wd/hub/"), caps);
        }

        [Given(@"I am on the google page")]
        public void GivenIAmOnTheGooglePage()
        {
            driver.Navigate().GoToUrl("https://www.google.com/ncr");
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string keyword)
        {
            var q = driver.FindElement(By.Name("q"));
            q.SendKeys(keyword);
            q.Submit();
        }

        [Then(@"I should see title ""(.*)""")]
        public void ThenIShouldSeeTitle(string title)
        {
            Thread.Sleep(5000);
            //Assert.That(_driver.Title, Is.EqualTo(title));
            driver.Quit();
        }
    }
}
