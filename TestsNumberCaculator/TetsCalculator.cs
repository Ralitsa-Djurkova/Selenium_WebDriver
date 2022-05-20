using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestsNumberCaculator
{
    public class Tests
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Url = " https://number-calculator.nakov.repl.co/";
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void Test_Sum_With_ValidNumbers()
        {
            driver.FindElement(By.CssSelector("#number1")).SendKeys("5");
            driver.FindElement(By.CssSelector("#operation")).SendKeys("+(sum)");
            driver.FindElement(By.CssSelector("#number2")).SendKeys("5");

            driver.FindElement(By.CssSelector("#calcButton")).Click();
            var result = driver.FindElement(By.CssSelector("#result > pre")).Text;

            Assert.That(result, Is.EqualTo("10"));
           
        }
    }
}