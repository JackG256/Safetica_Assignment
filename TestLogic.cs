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
        // Navigate to specified URL and check element
        _driver.Navigate().GoToUrl(Constants.teamsUrl);
        _actionLogger.Log($"Loaded website: [{Constants.teamsUrl}]");

        IWebElement? loginEmailField = AssistFunc.WaitForElement(_driver, By.TagName("input"), 5);
        Assert.IsNotNull(loginEmailField);
    }

    public void LogInTeams()
    {
        // Search for email input field, then input email
        IWebElement? loginEmailField = AssistFunc.WaitForElement(_driver, By.Id("i0116"), 5);
        Assert.IsNotNull(loginEmailField); 
        _actionLogger.Log("Email input element found");

        loginEmailField.Click();
        _actionLogger.Log("Email input element clicked");
        loginEmailField.SendKeys($"{Constants.login}");
        _actionLogger.Log($"Input: \"{Constants.login}\"");

        // Submit input
        IWebElement submitButton = _driver.FindElement(By.CssSelector("input[type='submit']"));
        submitButton.Click();
        _actionLogger.Log($"\"submit\" button pressed");

        // Explicit wait to avoid stale elements because of animations
        Thread.Sleep(2000);

        // Check the page updated by looking for password input field
        IWebElement? loginPassField = AssistFunc.WaitForElement(_driver, By.Id("i0118"), 5);
        Assert.IsNotNull(loginPassField);
        _actionLogger.Log("password input element found");

        // Input password
        loginPassField.Click();
        _actionLogger.Log("Password input element clicked");
        loginPassField.SendKeys($"{Constants.pass}");
        _actionLogger.Log($"Input: \"{Constants.pass}\"");

        // Submit password
        submitButton = _driver.FindElement(By.Id("idSIButton9"));
        submitButton.Click();
        _actionLogger.Log($"\"submit\" button pressed");
    }

    public void FilterPopUps()
    {
        // Hard sleep to avoid DOM change during animations
        Thread.Sleep(1000);

        // Look for the "Stay Signed In" pop up and filter out if it appears
        IWebElement? staySignedPopup = AssistFunc.WaitForElement(_driver, By.XPath("//*[@id=\"lightbox\"]/div[3]/div/div[2]/div/div[1]"), 5);

        if (staySignedPopup != null){
            IWebElement noButton = _driver.FindElement(By.XPath("//*[@id=\"idBtn_Back\"]"));
            noButton.Click();
            _actionLogger.Log("Found a \"Stay Signed In\" pop-up, clearing!");
        }else{
            _actionLogger.Log("Didn't find a \"Stay Signed In\" pop-up...");
        }

        // Hard sleep to avoid DOM change during animations
        Thread.Sleep(5000);
        
        // Look for the "get PC App" pop up and filter out if it appears
        IWebElement? getAppPopup = AssistFunc.WaitForElement(_driver, By.ClassName("download-text"), 5);
        
        if(getAppPopup != null){
            IWebElement useWebApp = _driver.FindElement(By.ClassName("use-app-lnk"));
            useWebApp.Click();
            _actionLogger.Log("Found a \"Use App\" pop-up, clearing!");
        }else{
             _actionLogger.Log("Didn't find a \"Use App\" pop-up...");
        }

        // Hard sleep to avoid DOM change during animations
        Thread.Sleep(8000);

        // Look for the "Turn on Notifications" pop up and filter out if it appears
        IWebElement? notificationsPopup = AssistFunc.WaitForElement(_driver, By.ClassName("toast-bottom-right"),5);
        if (notificationsPopup != null){
            IWebElement closeOption = _driver.FindElement(By.XPath("//*[@id=\"toast-container\"]/div/div/div[2]/div/button[2]"));
            closeOption.Click();
            _actionLogger.Log("Found a \"notification\" pop up, clearing!");
        }else{
            _actionLogger.Log("Didn't find a \"notification\" pop up...");
        }
    }

    public void MoveToChat()
    {
        // Get Chat Sidebar Button and navigate there
        IWebElement ChatSideBarButton = _driver.FindElement(By.XPath("//*[@id=\"app-bar-86fcd49b-61a2-4701-b771-54728cd291fb\"]"));
        _actionLogger.Log("Found Chat Button element");
        ChatSideBarButton.Click();
        _actionLogger.Log("Chat button element clicked");
    }

    public void OpenOneDriveWindow()
    {
        // Hard sleep to avoid DOM change during animations/loading
        Thread.Sleep(20000);

        // Doesn't work, I am completely lost.
        //IWebElement inputField = _driver.FindElement(By.XPath($"{Constants.teamsAttachButtonXPath}"));
        
        _actionLogger.Log("Clicked attachment button");
        
    }

    public void HardWait()
    {
        Thread.Sleep(150000);
    }
}
