namespace Safetica_Assignment;

public class Logger
{
	// Initiate path variable  to file
	private readonly string logFilePath;
	
	public Logger(string logDirectory, string logFileName)
	{	
		// Navigate to project root folder  
		string baseDir = AppDomain.CurrentDomain.BaseDirectory; 
		string projectRoot = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..")); 
		string fullLogDirectory = Path.Combine(projectRoot, logDirectory);

		// If specified directory doesn't yet exist, create it
		if (!Directory.Exists(fullLogDirectory))
		{
			Directory.CreateDirectory(fullLogDirectory);
		}

		// Create log file in directory
		logFilePath = Path.Combine(fullLogDirectory, logFileName);
	}

	// Logging function
	public void Log(string message)
	{
		// Create message from method call and append to file
		string logMessage = $"[{DateTime.Now:dd-MM-yyyy; hh:mm:ss}] - {message}";
		File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
	}
}
