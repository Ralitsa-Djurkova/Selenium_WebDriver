using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class SoftUniTests
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void ShutDown()
        {
            
            driver.Quit();
        }
        [Test]
        public void Test_Assert_PageTitle()
        {
           
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";

            Assert.That(driver.Title, Is.EqualTo(expectedTitle));

        }
        [Test]
        public void Test_Assert_AboutUsTitle()
        {
            
            var zaNasElement = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            zaNasElement.Click();
            string expectedTitle = "За нас - Софтуерен университет";

            Assert.That(driver.Title, Is.EqualTo(expectedTitle));

        }
        [Test]
        public void Test_Login_Invalid_Username_And_Password()
        {
            
            
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();
            driver.FindElement(By.Id("username")).SendKeys("Djurkova");
            driver.FindElement(By.Id("password-input")).SendKeys("Ralitsa1207");
            
            driver.FindElement(By.Id("username")).SendKeys("user1");
            driver.FindElement(By.Id("password-input")).SendKeys("user1");
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));
            driver.Close();
        }
    }
}