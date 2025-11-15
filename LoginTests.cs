using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using System; 

public class LoginTests : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly LoginPage _loginPage;

    public LoginTests()
    {
        
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--headless"); 
        chromeOptions.AddArgument("--no-sandbox"); 
        chromeOptions.AddArgument("--disable-dev-shm-usage"); 

        
        _driver = new ChromeDriver(chromeOptions); 
        
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        _loginPage = new LoginPage(_driver);
    }

    [Fact]
    public void TestSuccessfulLogin()
    {

        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");


        _loginPage.Login("tomsmith", "SuperSecretPassword!");


        var messageText = _loginPage.GetSuccessMessageText();
        Assert.Contains("You logged into a secure area!", messageText);
    }

    [Fact]
    public void TestFailedLogin()
    {

        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");


        _loginPage.Login("bad_user", "bad_password");


        var messageText = _loginPage.GetErrorMessageText();
        Assert.Contains("Your username is invalid!", messageText);
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}