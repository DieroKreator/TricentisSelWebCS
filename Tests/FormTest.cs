namespace FormTest;

using System;
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
        driver.Manage().Window.Maximize();

    }

    [TearDown] // Configura um método para ser usado depois dos testes
    public void After()
    {
        driver.Quit();
    }

    [Test] // Indica que é um método de teste
    public void SendForm()
    {
        driver = new ChromeDriver();

        // Navigate to url and assert
        var motorcycleInsurancePage = new MotorcycleInsurancePage(driver);
        motorcycleInsurancePage.GoTo();
        Assert.IsTrue(motorcycleInsurancePage.IsVisible);

        // Fill out the Vehicle form and submit
        motorcycleInsurancePage.FillVehicleFormAndSubmit();
        Assert.IsTrue(motorcycleInsurancePage.IsVisible);

        // Fill out the Insurance form and submit
        motorcycleInsurancePage.FillInsuranceFormAndSubmit();

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

    internal void FillVehicleFormAndSubmit()
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

    internal void FillInsuranceFormAndSubmit()
    {
        Driver.FindElement(By.Id("firstname")).SendKeys("Charlie");
        Driver.FindElement(By.Id("lastname")).SendKeys("Kamp");
        Driver.FindElement(By.Id("birthdate")).SendKeys("10/01/2000");

        SelectDropdownByValue(By.Id("country"), "Angola");

        Driver.FindElement(By.Id("zipcode")).SendKeys("1252014");

        SelectDropdownByValue(By.Id("occupation"), "Employee");

        /* Selecionar Hobbies com validação */

    }
}