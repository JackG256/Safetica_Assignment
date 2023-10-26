namespace Safetica_Assignment;

public class Logger
{
    // Initiate path variable  to file
    private readonly string _logFilePath;
    
    public Logger(string logDirectory, string logFileName)
    {
        var baseDir = AppDomain.CurrentDomain.BaseDirectory; 
        var projectRoot = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..")); 
        var fullLogDirectory = Path.Combine(projectRoot, logDirectory);

        if (!Directory.Exists(fullLogDirectory))
        {
            Directory.CreateDirectory(fullLogDirectory);
        }

        _logFilePath = Path.Combine(fullLogDirectory, logFileName);
        Console.WriteLine("Jsi kokot");
    }

    // Logging function
    public void Log(string message)
    {
        var logMessage = $"[{DateTime.Now:dd-MM-yyyy; hh:mm:ss}] - {message}";
        File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
    }
}
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

    [TestFixture]
    public class ChromeTests : CommonTest
    {
        [Test]
        public void ChromeTest()
        {
                Assert.Pass();
        }

        [Test]
        public void ChromeTest2()
        {
                Assert.Pass();
        }

        [Test]
        public void ChromeTest3()
        {
                Assert.Pass();
        }

        [Test]
        public void ChromeTest4()
        {
                Assert.Pass();
        }
    }

    [TearDown]
    public void TearDownCommon()
    {
        _testLogger.Log($"Test {TestContext.CurrentContext.Test.Name} finished with result: {TestContext.CurrentContext.Result.Outcome}");
        Console.WriteLine("Logged test result");
    }
}