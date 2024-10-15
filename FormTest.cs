namespace FormTest;

using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V126.Page;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

[TestFixture]
public class SendEnterInsuranceDataForm
{

#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    private IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

    [SetUp] // Configura um método para ser executado antes dos testes
    public void Before()
    {

    }

    [TearDown] // Configura um método para ser usado depois dos testes
    public void After()
    {

    }

    [Test] // Indica que é um método de teste
    public void SendForm()
    {
        driver = new ChromeDriver();

        // Navigate to url and assert
        var motorcycleInsurancePage = new MotorcycleInsurancePage(driver);
        motorcycleInsurancePage.GoTo();
        Assert.IsTrue(motorcycleInsurancePage.IsVisible);

        // Fill out the form and submit
        motorcycleInsurancePage.FillOutFormAndSubmit();
        Assert.IsTrue(motorcycleInsurancePage.IsVisible);

    }

    // private IWebDriver GetChromeDriver()
    // {
    //     var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    //     return new ChromeDriver(outPutDirectory);
    // }
}

internal class MotorcycleInsurancePage
{
    // Better make it property to know where is this used
    private IWebDriver Driver { get; set; }

    public MotorcycleInsurancePage(IWebDriver driver)
    {
        Driver = driver;
    }

    public bool? IsVisible
    {
        get
        {
            // Assert.That(bool.Parse(driver.Title), "Enter Vehicle Data");
            return Driver.Title.Contains("Enter Vehicle Data");

        }
        internal set { }
    }

    internal void FillOutFormAndSubmit(string make)
    {
        SelectDropdownByValue(By.Id("make"), "BMW");
        SelectDropdownByValue(By.Id("model"), "Motorcycle");

        Driver.FindElement(By.Id("cylindercapacity")).SendKeys("1000");
        Driver.FindElement(By.Id("engineperformance")).SendKeys("200");
        Driver.FindElement(By.Id("dateofmanufacture")).SendKeys("10/03/2024");

        SelectDropdownByValue(By.Id("numberofseats"), "3");
        SelectDropdownByValue(By.Id("numberofseatsmotorcycle"), "3");
        SelectDropdownByValue(By.Id("fuel"), "Diesel");

        Driver.FindElement(By.Id("payload")).SendKeys("197");
        Driver.FindElement(By.Id("totalweight")).SendKeys("197");
        Driver.FindElement(By.Id("listprice")).SendKeys("80000");
        Driver.FindElement(By.Id("annualmileage")).SendKeys("20000");

        // Navigate to next page of Form 'Enter Insurance Data'
        Driver.FindElement(By.Id("nextenterinsurantdata")).Click();
        Driver.FindElement(By.CssSelector("label.main")).Displayed.Equals(true);

    }

    internal void GoTo()
    {
        Driver.Navigate().GoToUrl("http://sampleapp.tricentis.com/101/app.php");
    }

    // Method to select an option by value
    public void SelectDropdownByValue(By by, string value)
    {
        IWebElement dropdownElement = Driver.FindElement(by);
        SelectElement select = new SelectElement(dropdownElement);
        select.SelectByValue(value);
    }

}