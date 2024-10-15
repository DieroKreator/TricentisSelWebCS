namespace FormTest;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class SendEnterInsuranceDataForm
{

#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    private IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

    [Test] // Indica que é um método de teste
    public void SendForm()
    {
        // Navigate to url and assert
        var motorcycleInsurancePage = new MotorcycleInsurancePage(driver);
        motorcycleInsurancePage.GoTo();
        Assert.IsTrue(motorcycleInsurancePage.IsVisible);

        // Fill out the Vehicle form and submit
        motorcycleInsurancePage.FillVehicleFormAndSubmit();

        // Fill out the Insurance form and submit
        motorcycleInsurancePage.FillInsuranceFormAndSubmit();

    }

    // private IWebDriver GetChromeDriver()
    // {
    //     var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    //     return new ChromeDriver(outPutDirectory);
    // }
}