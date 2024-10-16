namespace TricentisSelWebCS.Tests;

using OpenQA.Selenium;

[TestFixture]
public class SendEnterInsuranceDataForm : TestBase 
{
    private IWebDriver? Driver { get; set; }

    [Test] // Indica que é um método de teste
    public void SendForm()
    {
        // Navigate to url and assert
        var motorcycleInsurancePage = new MotorcycleInsurancePage(Driver);
        motorcycleInsurancePage.GoTo();
        Assert.IsTrue(motorcycleInsurancePage.IsVisible, "Motorcycle Insurance Page was not visible.");

        // Fill out the Vehicle form and submit
        motorcycleInsurancePage.FillVehicleFormAndSubmit();

        // Fill out the Insurance form and submit
        motorcycleInsurancePage.FillInsuranceFormAndSubmit();

    }

}