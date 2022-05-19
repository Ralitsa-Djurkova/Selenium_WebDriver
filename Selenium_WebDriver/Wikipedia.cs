


using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

var driver = new ChromeDriver();
driver.Url = "https://www.wikipedia.org/";

var serschField = driver.FindElement(By.Id("searchInput"));
serschField.Click();
serschField.SendKeys("QA");
serschField.SendKeys(Keys.Enter);

driver.Quit();
