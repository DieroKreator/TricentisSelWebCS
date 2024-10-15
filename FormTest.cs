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
        IWebElement makeDropdown = Driver.FindElement(By.Id("make"));
        IWebElement modelDropdown = Driver.FindElement(By.Id("model"));

        SelectElement selectElement = new SelectElement(makeDropdown);

        selectElement.SelectByText("BMW");

        dropdown = Driver.FindElement(By.Id("make"));

        SelectElement selectElement = new SelectElement(dropdown);

        selectElement.SelectByText("BMW");
        
        SelectDropdownByValue(By.Id("make"), "BMW");

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