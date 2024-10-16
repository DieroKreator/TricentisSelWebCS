namespace FormTest;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class SendEnterInsuranceDataForm : TestBase 
{
    private IWebDriver driver;

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

}