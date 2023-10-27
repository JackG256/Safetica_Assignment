namespace Safetica_Assignment;

public class CommonTest
{
    protected static Logger _actionLogger;
    protected static Logger _testLogger;
    
    static CommonTest()
    {
        var timestamp = DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss");
        _testLogger = new Logger("test_runs", $"{timestamp}.txt");
        _actionLogger = new Logger("action_logs", $"{timestamp}.txt");
        Console.WriteLine("Common setup finished");
    }

    [SetUp]
    public void SetupCommon()
    {
        _testLogger.Log($"Running test: {TestContext.CurrentContext.Test.Name}");
        Console.WriteLine("Logged test run");
    }



    [TearDown]
    public void TearDownCommon()
    {
        _testLogger.Log($"Test {TestContext.CurrentContext.Test.Name} finished with result: {TestContext.CurrentContext.Result.Outcome}");
        Console.WriteLine("Logged test result");
    }
}