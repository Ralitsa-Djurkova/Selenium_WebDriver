using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SummatorOfNumbers
{
    public class Tests
    {
        private WebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://sum-numbers.nakov.repl.co";
            driver.Manage().Window.Maximize();


        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Add_TwoNumbers_Valid()
        {
            driver.FindElement(By.CssSelector("#number1")).SendKeys("7");
            driver.FindElement(By.CssSelector("#number2")).SendKeys("5");
            var clickButton = driver.FindElement(By.Id("calcButton"));
            clickButton.Click();
            var result = driver.FindElement(By.CssSelector("#result")).Text;
            Assert.That(result, Is.EqualTo("Sum: 12"));
        }
        [Test]
        public void Test_Add_TwoNumbers_Invalid()
        {
            driver.FindElement(By.CssSelector("#number1")).SendKeys("hel");
            driver.FindElement(By.CssSelector("#number2")).SendKeys("hnd");
            var clickButton = driver.FindElement(By.Id("calcButton"));
            clickButton.Click();
            var result = driver.FindElement(By.CssSelector("#result > i")).Text; ;
            Assert.That(result, Is.EqualTo("invalid input"));
        }
        [Test]
        public void Test_Add_TwoNumbersField_Are_Empty()
        {
            driver.FindElement(By.CssSelector("#number1")).SendKeys(" ");
            driver.FindElement(By.CssSelector("#number2")).SendKeys(" ");
            var clickButton = driver.FindElement(By.Id("calcButton"));
            clickButton.Click();
            var result = driver.FindElement(By.CssSelector("#result > i")).Text; ;
            Assert.That(result, Is.EqualTo("invalid input"));
        }

        [Test]
        public void Test_Add_TwoNumbers_ReserNutton_Works_Correctly()
        {
            driver.FindElement(By.CssSelector("#number1")).SendKeys("1");
            driver.FindElement(By.CssSelector("#number2")).SendKeys("1");
            var clickButton = driver.FindElement(By.Id("calcButton"));
            clickButton.Click();
            var result = driver.FindElement(By.CssSelector("#result > pre")).Text; 
            
            
            Assert.That(result, Is.EqualTo("2"));

            var buttonReset = driver.FindElement(By.CssSelector("#resetButton"));
            buttonReset.Click();
            var result2 = driver.FindElement(By.CssSelector("#number1")).Text;
            var result1 = driver.FindElement(By.CssSelector("#number2")).Text;

            Assert.That(result1, Is.EqualTo(string.Empty));
            Assert.That(result2, Is.EqualTo(string.Empty));
        }
        
    }
}