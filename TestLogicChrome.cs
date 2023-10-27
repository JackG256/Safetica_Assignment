using Safetica_Assignment.AssistFunctions;
namespace Safetica_Assignment.PageObjects;

public class TeamsPage
{
    private readonly IWebDriver _driver;
    private readonly Logger _actionLogger;

    // Page constructor, passed driver and actionlogger classes to work with
    public TeamsPage(IWebDriver driver, Logger actionLogger)
    {
        _driver = driver;
        _actionLogger = actionLogger;
    }

    
    public void LoadTeamsPage()
    {
        _driver.Navigate().GoToUrl(Constants.teamsUrl);
        _actionLogger.Log($"Loaded website: [{Constants.teamsUrl}]");

        IWebElement loginEmailField = AssistFunc.WaitForElement(_driver, By.TagName("input"), 5);
        Assert.IsNotNull(loginEmailField);
    }

    public void LogInTeams()
    {
        // Search for email input field, then input email
        IWebElement loginEmailField = AssistFunc.WaitForElement(_driver, By.Id("i0116"), 5);
        Assert.IsNotNull(loginEmailField); 
        _actionLogger.Log("Email input element found");

        loginEmailField.Click();
        loginEmailField.SendKeys($"{Constants.login}");
        _actionLogger.Log($"User input: \"{Constants.login}\"");

        // Submit input
        IWebElement submitButton = _driver.FindElement(By.CssSelector("input[type='submit']"));
        submitButton.Click();
        _actionLogger.Log($"User pressed \"submit\" button");

        // Explicit wait to avoid stale elements because of animations
        Thread.Sleep(1000);

        // Check the page updated by looking for password input field
        IWebElement loginPassField = AssistFunc.WaitForElement(_driver, By.Id("i0118"), 5);
        Assert.IsNotNull(loginPassField);
        _actionLogger.Log("password input element found");

        // Input password
        loginPassField.Click();
        _actionLogger.Log("Input clicked");
        loginPassField.SendKeys($"{Constants.pass}");
        _actionLogger.Log($"User input: \"{Constants.pass}\"");

        // Submit password
        submitButton = _driver.FindElement(By.TagName("input[type='submit']"));
        submitButton.Click();
        _actionLogger.Log($"User pressed \"submit\" button");
    }

    public void FilterPopUps()
    {
        IWebElement staySignedPopup = AssistFunc.WaitForElement(_driver, By.LinkText("Zůstat přihlášen(a)?"), 5);
        if (staySignedPopup == null){
            staySignedPopup = AssistFunc.WaitForElement(_driver, By.LinkText("Stay signed in?"), 5);
        }

        if (staySignedPopup != null){
            IWebElement noButton = _driver.FindElement(By.TagName("button"));
            noButton.Click();
        }


        IWebElement getAppPopup = AssistFunc.WaitForElement(_driver, By.LinkText("Stáhněte si aplikaci Teams pro plochu a zajistěte si lepší připojení."), 5);
        if (getAppPopup == null){
            getAppPopup = AssistFunc.WaitForElement(_driver, By.LinkText("Download the Teams desktop app and stay better connected."), 5);
        }
        
        if(getAppPopup != null){
            IWebElement useWebApp = _driver.FindElement(By.ClassName("use-app-lnk"));
            useWebApp.Click();
        }
    }
}
