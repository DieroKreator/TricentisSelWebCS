using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class MotorcycleInsurancePage : TestBase
{

    // Better make it property to know where is this used
    private IWebDriver Driver { get; set; }
    public IWebElement CilinderCapacityField => Driver.FindElement(By.Id("cylindercapacity"));
    public IWebElement EnginePerformanceField => Driver.FindElement(By.Id("engineperformance"));
    public IWebElement DateOfManufactureField => Driver.FindElement(By.Id("dateofmanufacture"));
    public IWebElement PayloadField => Driver.FindElement(By.Id("payload"));
    public IWebElement TotalWeightField => Driver.FindElement(By.Id("totalweight"));
    public IWebElement ListPriceField => Driver.FindElement(By.Id("listprice"));
    public IWebElement AnnualMileageField => Driver.FindElement(By.Id("annualmileage"));
    public IWebElement NextEnterInsurantDataButton => Driver.FindElement(By.Id("nextenterinsurantdata"));

    public MotorcycleInsurancePage(IWebDriver driver)
    {
        Driver = driver;
    }

    public bool? IsVisible
    {
        get
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                IWebElement NextEnterInsurantDataButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("nextenterinsurantdata")));
                return NextEnterInsurantDataButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                // return Driver.Title.Contains("Enter Vehicle Data");
                return false;
            }            

        }
        internal set { }
    }

    internal void FillVehicleFormAndSubmit()
    {
        SelectDropdownByValue(By.Id("make"), "BMW");
        SelectDropdownByValue(By.Id("model"), "Motorcycle");

        CilinderCapacityField.SendKeys("1000");
        EnginePerformanceField.SendKeys("200");
        DateOfManufactureField.SendKeys("10/03/2024");

        SelectDropdownByValue(By.Id("numberofseats"), "3");
        SelectDropdownByValue(By.Id("numberofseatsmotorcycle"), "3");
        SelectDropdownByValue(By.Id("fuel"), "Diesel");

        PayloadField.SendKeys("197");
        TotalWeightField.SendKeys("197");
        ListPriceField.SendKeys("80000");
        AnnualMileageField.SendKeys("20000");

        // Navigate to next page of Form 'Enter Insurance Data'
        NextEnterInsurantDataButton.Click();
        Driver.FindElement(By.CssSelector("label.main")).Displayed.Equals(true);

    }

    internal void GoTo()
    {
        Driver.Navigate().GoToUrl("http://sampleapp.tricentis.com/101/app.php");
        Assert.That(bool.Parse(driver.Title), "Enter Vehicle Data");
    }

    // Method to select an option by value
    public void SelectDropdownByValue(By by, string value)
    {
        IWebElement dropdownElement = Driver.FindElement(by);
        SelectElement select = new SelectElement(dropdownElement);
        select.SelectByValue(value);
    }

    public IWebElement FirstNameField => Driver.FindElement(By.Id("firstname"));
    public IWebElement LastNameField => Driver.FindElement(By.Id("lastname"));
        public IWebElement BirthDateField => Driver.FindElement(By.Id("birthdate"));

        public IWebElement ZipCodeField => Driver.FindElement(By.Id("zipcode"));
                public IWebElement NextEnterProductDataButton => Driver.FindElement(By.Id("nextenterproductdata"));




    internal void FillInsuranceFormAndSubmit()
    {
        FirstNameField.SendKeys("Charlie");
        LastNameField.SendKeys("Kamp");
        BirthDateField.SendKeys("10/01/2000");

        SelectDropdownByValue(By.Id("country"), "Angola");

        ZipCodeField.SendKeys("1252014");

        SelectDropdownByValue(By.Id("occupation"), "Employee");

        Thread.Sleep(3000);

        /* Selecionar Hobbies */
        CheckMultipleCheckboxes(By.XPath("//label[contains(., \"Speeding\")]/input"), By.XPath("//label[contains(., \"Skydiving\")]/input"));

        // Assertion
        AssertMultipleCheckboxesChecked(By.XPath("//label[contains(., \"Speeding\")]/input"), By.XPath("//label[contains(., \"Skydiving\")]/input"));

        // Navigate to next page of Form 'Enter Product Data'
        NextEnterProductDataButton.Click();
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