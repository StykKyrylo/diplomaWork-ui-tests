using OpenQA.Selenium;

public class LoginPage
{
    private readonly IWebDriver _driver;

    
    private readonly By _usernameInput = By.Id("username");
    private readonly By _passwordInput = By.Id("password");
    private readonly By _loginButton = By.CssSelector("button[type='submit']");
    private readonly By _successMessage = By.Id("flash");
    private readonly By _errorMessage = By.Id("flash");

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    
    public void Login(string username, string password)
    {
        _driver.FindElement(_usernameInput).SendKeys(username);
        _driver.FindElement(_passwordInput).SendKeys(password);
        _driver.FindElement(_loginButton).Click();
    }

    public string GetSuccessMessageText()
    {
        return _driver.FindElement(_successMessage).Text;
    }

    public string GetErrorMessageText()
    {
        return _driver.FindElement(_errorMessage).Text;
    }
}