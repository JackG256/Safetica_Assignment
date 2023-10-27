namespace Safetica_Assignment.AssistFunctions;

public class AssistFunc
{
    public static IWebElement? WaitForElement(IWebDriver driver, By locator, int timeoutSeconds)
    {
        
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
        try
        {
            return wait.Until(drv => drv.FindElement(locator));
        }catch(WebDriverTimeoutException){
            return null;
        }
    } 
}