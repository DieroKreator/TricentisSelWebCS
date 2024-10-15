using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class MotorcycleInsurancePage : TestBase
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

        Thread.Sleep(3000);

        /* Selecionar Hobbies */
        CheckMultipleCheckboxes(By.XPath("//label[contains(., \"Speeding\")]/input"), By.XPath("//label[contains(., \"Skydiving\")]/input"));

        // Assertion
        AssertMultipleCheckboxesChecked(By.XPath("//label[contains(., \"Speeding\")]/input"), By.XPath("//label[contains(., \"Skydiving\")]/input"));

        // Navigate to next page of Form 'Enter Product Data'
        Driver.FindElement(By.Id("nextenterproductdata")).Click();
        Driver.FindElement(By.CssSelector("input[name=\"Start Date\"]")).Displayed.Equals(true);
    }

    // Method to check a single checkbox by its locator
    public void CheckCheckbox(By checkboxLocator)
    {
        IWebElement checkbox = Driver.FindElement(checkboxLocator);
        if (!checkbox.Selected)  // Check if it's not already selected
        {
            checkbox.Click();
        }
    }

    // Method to check multiple checkboxes by their locators
    public void CheckMultipleCheckboxes(params By[] checkboxLocators)
    {
        foreach (By locator in checkboxLocators)
        {
            CheckCheckbox(locator);  // Call the CheckCheckbox method for each locator
        }
    }

    // Method to assert that a checkbox is checked
    public void AssertCheckboxChecked(By checkboxLocator)
    {
        IWebElement checkbox = Driver.FindElement(checkboxLocator);
        Assert.IsTrue(checkbox.Selected, "Checkbox is not checked as expected!");
    }

    // Method to assert multiple checkboxes are checked
    public void AssertMultipleCheckboxesChecked(params By[] checkboxLocators)
    {
        foreach (By locator in checkboxLocators)
        {
            AssertCheckboxChecked(locator);  // Call the assert method for each locator
        }
    }

}