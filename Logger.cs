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
	}

	// Logging function
	public void Log(string message)
	{
		var logMessage = $"[{DateTime.Now:dd-MM-yyyy; hh:mm:ss}] - {message}";
		File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
	}
}
