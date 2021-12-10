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
        String username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
        String accessKey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");

        public SingleSteps()
        {
            OpenQA.Selenium.Chrome.ChromeOptions capability = new OpenQA.Selenium.Chrome.ChromeOptions();
            capability.AddAdditionalCapability("os_version", "10", true);
            capability.AddAdditionalCapability("browser", "Chrome", true);
            capability.AddAdditionalCapability("browser_version", "latest", true);
            capability.AddAdditionalCapability("os", "Windows", true);
            capability.AddAdditionalCapability("name", "Google Search Test", true); // test name
            capability.AddAdditionalCapability("build", "browserstack-specflow-sample", true); // CI/CD job or build name
            capability.AddAdditionalCapability("browserstack.user", username, true);
            capability.AddAdditionalCapability("browserstack.key", accessKey, true);
            driver = new RemoteWebDriver(
            new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Given(@"I am on the Bstackdemo website and click on signin")]
        public void GivenIAmOnTheBstacdemoWebsiteAndClickOnSignin()
        {
            driver.Navigate().GoToUrl("https://bstackdemo.com/");
            driver.FindElement(By.Id("signin")).Click();
        }

        [When(@"I enter ""(.*)"" and ""(.*)""")]
        public void WhenIEnter(string username,String password)
        {
            try
            {
                driver.FindElement(By.CssSelector("#username input")).SendKeys(username);
                driver.FindElement(By.CssSelector("#username input")).SendKeys(Keys.Enter);
                driver.FindElement(By.CssSelector("#password input")).SendKeys(password);
                driver.FindElement(By.CssSelector("#password input")).SendKeys(Keys.Enter);

                driver.FindElement(By.Id("login-btn")).Click();

            }
            catch (Exception e)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \"Something went wrong!\"}}");
                Console.WriteLine(e);
            }

        }

        [Then(@"I should see user as ""(.*)""")]
        public void ThenIShouldSeeUserAs(string user)
        {
            String verifyUser = driver.FindElement(By.ClassName("username")).Text;
            if (verifyUser.Equals(user))
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \"Expected\"}}");

            }
            else
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \"Unexpected\"}}");
            }
            System.Threading.Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
