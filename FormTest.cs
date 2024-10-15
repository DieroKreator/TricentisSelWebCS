namespace FormTest;

using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V126.Page;

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
    private IWebDriver driver;

    public MotorcycleInsurancePage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public bool? IsVisible { get; internal set; }

    internal void FillOutFormAndSubmit()
    {
        throw new NotImplementedException();
    }

    internal void GoTo()
    {
        driver.Navigate().GoToUrl("http://sampleapp.tricentis.com/101/app.php");
        // Assert.That(bool.Parse(driver.Title), "Enter Vehicle Data");
    }

}