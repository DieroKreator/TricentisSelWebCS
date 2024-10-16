using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class TestBase
{
    protected IWebDriver driver;

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
        driver.Dispose();
    }
}