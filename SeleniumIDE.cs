namespace TricentisSelWebCS;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

[TestFixture]
public class SendentervehicledataformTest
{
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    private IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    public IDictionary<string, object> vars { get; private set; }
    private IJavaScriptExecutor js;
    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();
    }
    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
    }
    [Test]
    public void sendentervehicledataform()
    {
        // Test name: Send enter vehicle data form
        // Step # | name | target | value | comment
        // 1 | open | /101/app.php |  | 
        driver.Navigate().GoToUrl("https://sampleapp.tricentis.com/101/app.php");
        // 2 | setWindowSize | 1082x770 |  | 
        driver.Manage().Window.Size = new System.Drawing.Size(1082, 770);
        // 3 | click | id=make |  | 
        driver.FindElement(By.Id("make")).Click();
        // 4 | select | id=make | label=Honda | 
        {
            var dropdown = driver.FindElement(By.Id("make"));
            dropdown.FindElement(By.XPath("//option[. = 'Honda']")).Click();
        }
        // 5 | click | id=model |  | 
        driver.FindElement(By.Id("model")).Click();
        // 6 | select | id=model | label=Scooter | 
        {
            var dropdown = driver.FindElement(By.Id("model"));
            dropdown.FindElement(By.XPath("//option[. = 'Scooter']")).Click();
        }
        // 7 | click | id=cylindercapacity |  | 
        driver.FindElement(By.Id("cylindercapacity")).Click();
        // 8 | type | id=cylindercapacity | 1000 | 
        driver.FindElement(By.Id("cylindercapacity")).SendKeys("1000");
        // 9 | type | id=engineperformance | 200 | 
        driver.FindElement(By.Id("engineperformance")).SendKeys("200");
        // 10 | click | css=#opendateofmanufacturecalender > .fa |  | 
        driver.FindElement(By.CssSelector("#opendateofmanufacturecalender > .fa")).Click();
        // 11 | click | linkText=14 |  | 
        driver.FindElement(By.LinkText("14")).Click();
        // 12 | click | id=numberofseatsmotorcycle |  | 
        driver.FindElement(By.Id("numberofseatsmotorcycle")).Click();
        // 13 | select | id=numberofseatsmotorcycle | label=2 | 
        {
            var dropdown = driver.FindElement(By.Id("numberofseatsmotorcycle"));
            dropdown.FindElement(By.XPath("//option[. = '2']")).Click();
        }
        // 14 | click | id=listprice |  | 
        driver.FindElement(By.Id("listprice")).Click();
        // 15 | type | id=listprice | 80000 | 
        driver.FindElement(By.Id("listprice")).SendKeys("80000");
        // 16 | click | id=annualmileage |  | 
        driver.FindElement(By.Id("annualmileage")).Click();
        // 17 | type | id=annualmileage | 20000 | 
        driver.FindElement(By.Id("annualmileage")).SendKeys("20000");
        // 18 | click | id=nextenterinsurantdata |  | 
        driver.FindElement(By.Id("nextenterinsurantdata")).Click();
        // 19 | assertText | css=.idealsteps-step:nth-child(2) > .field:nth-child(1) > .main | First Name | 
        Assert.That(driver.FindElement(By.CssSelector(".idealsteps-step:nth-child(2) > .field:nth-child(1) > .main")).Text, Is.EqualTo("First Name"));
        // 20 | click | id=firstname |  | 
        driver.FindElement(By.Id("firstname")).Click();
        // 21 | type | id=firstname | Charlie | 
        driver.FindElement(By.Id("firstname")).SendKeys("Charlie");
        // 22 | type | id=lastname | Kamp | 
        driver.FindElement(By.Id("lastname")).SendKeys("Kamp");
        // 23 | click | css=#opendateofbirthcalender > .fa |  | 
        driver.FindElement(By.CssSelector("#opendateofbirthcalender > .fa")).Click();
        // 24 | click | linkText=10 |  | 
        driver.FindElement(By.LinkText("10")).Click();
        // 25 | click | id=birthdate |  | 
        driver.FindElement(By.Id("birthdate")).Click();
        // 26 | type | id=birthdate | 10/10/2000 | 
        driver.FindElement(By.Id("birthdate")).SendKeys("10/10/2000");
        // 27 | click | css=.group:nth-child(2) > .ideal-radiocheck-label:nth-child(1) > .ideal-radio |  | 
        driver.FindElement(By.CssSelector(".group:nth-child(2) > .ideal-radiocheck-label:nth-child(1) > .ideal-radio")).Click();
        // 28 | click | id=country |  | 
        driver.FindElement(By.Id("country")).Click();
        // 29 | select | id=country | label=Angola | 
        {
            var dropdown = driver.FindElement(By.Id("country"));
            dropdown.FindElement(By.XPath("//option[. = 'Angola']")).Click();
        }
        // 30 | click | id=zipcode |  | 
        driver.FindElement(By.Id("zipcode")).Click();
        // 31 | type | id=zipcode | 1252014 | 
        driver.FindElement(By.Id("zipcode")).SendKeys("1252014");
        // 32 | click | id=occupation |  | 
        driver.FindElement(By.Id("occupation")).Click();
        // 33 | select | id=occupation | label=Employee | 
        {
            var dropdown = driver.FindElement(By.Id("occupation"));
            dropdown.FindElement(By.XPath("//option[. = 'Employee']")).Click();
        }
        // 34 | click | css=.ideal-radiocheck-label:nth-child(4) > .ideal-check |  | 
        driver.FindElement(By.CssSelector(".ideal-radiocheck-label:nth-child(4) > .ideal-check")).Click();
        // 35 | click | id=nextenterproductdata |  | 
        driver.FindElement(By.Id("nextenterproductdata")).Click();
        // 36 | assertText | css=.idealsteps-step:nth-child(3) > .idealforms-field-text > .main | Start Date | 
        Assert.That(driver.FindElement(By.CssSelector(".idealsteps-step:nth-child(3) > .idealforms-field-text > .main")).Text, Is.EqualTo("Start Date"));
        // 37 | close |  |  | 
        driver.Close();
    }
}
