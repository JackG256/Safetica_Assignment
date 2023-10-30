using Safetica_Assignment.AssistFunctions;
namespace Safetica_Assignment.PageObjects;

public class TeamsPage
{
    private readonly IWebDriver driver;
    private readonly Logger actionLogger;

    // Page constructor, passed driver and actionlogger classes to work with
    public TeamsPage(IWebDriver driver, Logger actionLogger)
    {
        this.driver = driver;
        this.actionLogger = actionLogger;
    }

    
    public void LoadTeamsPage()
    {
        // Navigate to specified URL and check element
        driver.Navigate().GoToUrl(Constants.teamsUrl);
        actionLogger.Log($"Loaded website: [{Constants.teamsUrl}]");

        IWebElement? loginEmailField = AssistFunc.WaitForElement(driver, By.TagName("input"), 5);
        Assert.IsNotNull(loginEmailField);
    }

    public void LogInTeams()
    {
        // Search for email input field, then input email
        IWebElement? loginEmailField = AssistFunc.WaitForElement(driver, By.Id("i0116"), 5);
        Assert.IsNotNull(loginEmailField); 
        actionLogger.Log("Email input element found");

        loginEmailField.Click();
        actionLogger.Log("Email input element clicked");
        loginEmailField.SendKeys($"{Constants.login}");
        actionLogger.Log($"Input: \"{Constants.login}\"");

        // Submit input
        IWebElement submitButton = driver.FindElement(By.CssSelector("input[type='submit']"));
        submitButton.Click();
        actionLogger.Log($"\"submit\" button pressed");

        // Explicit wait to avoid stale elements because of animations
        Thread.Sleep(2000);

        // Check the page updated by looking for password input field
        IWebElement? loginPassField = AssistFunc.WaitForElement(driver, By.Id("i0118"), 5);
        Assert.IsNotNull(loginPassField);
        actionLogger.Log("password input element found");

        // Input password
        loginPassField.Click();
        actionLogger.Log("Password input element clicked");
        loginPassField.SendKeys($"{Constants.pass}");
        actionLogger.Log($"Input: \"{Constants.pass}\"");

        // Submit password
        submitButton = driver.FindElement(By.Id("idSIButton9"));
        submitButton.Click();
        actionLogger.Log($"\"submit\" button pressed");
    }

    public void FilterPopUps()
    {
        // Hard sleep to avoid DOM change during animations
        Thread.Sleep(1000);

        // Look for the "Stay Signed In" pop up and filter out if it appears
        IWebElement? staySignedPopup = AssistFunc.WaitForElement(driver, By.XPath("//*[@id=\"lightbox\"]/div[3]/div/div[2]/div/div[1]"), 5);

        if (staySignedPopup != null){
            IWebElement noButton = driver.FindElement(By.XPath("//*[@id=\"idBtn_Back\"]"));
            noButton.Click();
            actionLogger.Log("Found a \"Stay Signed In\" pop-up, clearing!");
        }else{
            actionLogger.Log("Didn't find a \"Stay Signed In\" pop-up...");
        }

        // Hard sleep to avoid DOM change during animations
        Thread.Sleep(5000);
        
        // Look for the "get PC App" pop up and filter out if it appears
        IWebElement? getAppPopup = AssistFunc.WaitForElement(driver, By.ClassName("download-text"), 5);
        
        if(getAppPopup != null){
            IWebElement useWebApp = driver.FindElement(By.ClassName("use-app-lnk"));
            useWebApp.Click();
            actionLogger.Log("Found a \"Use App\" pop-up, clearing!");
        }else{
             actionLogger.Log("Didn't find a \"Use App\" pop-up...");
        }

        // Hard sleep to avoid DOM change during animations
        Thread.Sleep(8000);

        // Look for the "Turn on Notifications" pop up and filter out if it appears
        IWebElement? notificationsPopup = AssistFunc.WaitForElement(driver, By.ClassName("toast-bottom-right"),5);
        if (notificationsPopup != null){
            IWebElement closeOption = driver.FindElement(By.XPath("//*[@id=\"toast-container\"]/div/div/div[2]/div/button[2]"));
            closeOption.Click();
            actionLogger.Log("Found a \"notification\" pop up, clearing!");
        }else{
            actionLogger.Log("Didn't find a \"notification\" pop up...");
        }
    }

    public void MoveToChat()
    {
        // Get Chat Sidebar Button and navigate there
        IWebElement ChatSideBarButton = driver.FindElement(By.XPath("//*[@id=\"app-bar-86fcd49b-61a2-4701-b771-54728cd291fb\"]"));
        actionLogger.Log("Found Chat Button element");
        ChatSideBarButton.Click();
        actionLogger.Log("Chat button element clicked");
    }

    public void OpenOneDriveWindow()
    {
        // Hard sleep to avoid DOM change during animations/loading
        //Thread.Sleep(15000);

        // Doesn't work, web driver is unable to locate key elements (Attach button / chat input field)
        // Following is possible pseudocode to finish the test 
        // Functions dependent on this sequence will also be in pseudocode
        
        /* 
        // 
        IWebElement attachButton = driver.FindElement(By.XPath("AttachButton XPath"));
        attachbutton.click();
        actionLogger.Log("Clicked attachment button");
        IWebElement oneDriveAttach = AssistFunc.WaitForElement(driver, By.ClassName("drive-attach"),5);
        _ctionLogger.Log("Opened OneDrive dialog");
        */
    }

    public void AttachFile()
    {
        /*
        IWebElement? driveFileCheckbox = AssistFunc.WaitForElement(driver, By.ClassName("drive-file-check-icon"),5);
        Assert.IsNotNull(driveFileCheckbox); 
        driveFileCheckbox.Click();
        actionLogger.Log("Selected a file")
        */
    }

    public void AttachAnotherFile()
    {
        /*
        IWebElement driveFileCheckboxNext = driver.FindElement(By.ClassName("drive-file-check-icon"))
        driveFileCheckboxNext.Click();
        actionLogger.Log("Selected another file")
        */
    }

    public void ConfirmAttachment()
    {
        /*
        IWebElement attachConfirm = driver.FindElement(By.ClassName("attach-confirm-button"))
        attachConfirm.Click();
        actionLogger.Log("Attached multiple files to a message");
        */
    }

    public void SendMessage()
    {
        /*
        IWebElement? sendMessage = AssistFunc.WaitForElement(driver, By.ClassName("icon-message-send"),5);
        Assert.IsNotNull(sendMessage);
        sendMessage.Click();
        actionLogger.Log("Sent message");
        */
    }

    public void SendFullMessage()
    {
        /*
        IWebElement? chatBox = AssistFunc.WaitForElement(driver, By.ClassName("text-input-field"),5);
        Assert.IsNotNull(chatBox);
        chatBox.Click();
        actionLogger.Log("Clicked chat input field");

        chatBox.SendKeys("This is a message!");
        SendMessage();
        */
    }

    public void SendSplitMessage()
    {
        /*
        IWebElement? chatBox = AssistFunc.WaitForElement(driver, By.ClassName("text-input-field"),5);
        Assert.IsNotNull(chatBox);
        chatBox.Click();
        actionLogger.Log("Clicked chat input field");

        string[] messages ={"This",
                            "is", 
                            "SPARTA!, no wait...",
                            "a", 
                            "message." };

        foreach (var message in messages)
        {
            chatBox.SendKeys(message);
            SendMessage();
            
            // Failsafe to avoid losing focus
            chatBox.Click();
        }
        */
    }

    public void HardWait()
    {
        actionLogger.Log("Sleeping . . .");
        Thread.Sleep(10000);
    }
}
