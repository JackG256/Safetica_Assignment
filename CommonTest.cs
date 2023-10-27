namespace Safetica_Assignment;

public class CommonTest
{
	protected static Logger _actionLogger;
	protected static Logger _testLogger;
	
	// Static constructor to ensure only one instance of each logger
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
		// Set up is run each test, logs test start
		_testLogger.Log($"Running test: {TestContext.CurrentContext.Test.Name}");
		Console.WriteLine("Logged test run");
	}

	[TearDown]
	public void TearDownCommon()
	{
		// Tear down is run each test, logs the result of a test
		_testLogger.Log($"Test {TestContext.CurrentContext.Test.Name} finished with result: {TestContext.CurrentContext.Result.Outcome}");
		Console.WriteLine("Logged test result");
	}
}
