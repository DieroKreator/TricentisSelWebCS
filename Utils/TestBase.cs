using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class TestBase
{
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    protected IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

    [SetUp] // Configura um método para ser executado antes dos testes
    public void Before()
    {
        driver = new ChromeDriver();

        driver.Manage().Window.Maximize();

    }

    [TearDown] // Configura um método para ser usado depois dos testes
    public void After()
    {
        driver.Quit();
    }
}