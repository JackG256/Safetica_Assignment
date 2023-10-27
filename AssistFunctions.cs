namespace Safetica_Assignment.AssistFunctions;

public class AssistFunc
{
    // Function that waits for an element to be present in the DOM over specified time period
    // Returns element object or null if timed-out
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