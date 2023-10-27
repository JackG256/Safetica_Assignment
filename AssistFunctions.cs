namespace Safetica_Assignment.AssistFunctions;

public class AssistFunc
{
    public static IWebElement WaitForElement(IWebDriver driver, By locator, int timeoutSeconds)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
        return wait.Until(drv => drv.FindElement(locator));
    } 
}