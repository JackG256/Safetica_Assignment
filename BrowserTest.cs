using Safetica_Assignment.PageObjects;

namespace Safetica_Assignment;

[TestFixture]
public class TeamsChromeTests : CommonTest
{
 	private IWebDriver driver;
	private TeamsPage teamsPage;

	[SetUp]
	public void ChromeSetup()
	{
		// Get Chromedriver.exe, initialize the driver and pass it to test page
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string driverPath = Path.GetFullPath(Path.Combine(basePath, "..", "..", "..", "drivers"));

		// Initialize the driver
		driver = new ChromeDriver(driverPath);

		// Initiate the Teams page class
		teamsPage = new TeamsPage(driver, actionLogger);
	}

	[Test]
	public void SendOneDriveFile()
	{
			teamsPage.LoadTeamsPage();
			teamsPage.LogInTeams();
			teamsPage.FilterPopUps();
			teamsPage.MoveToChat();

			teamsPage.OpenOneDriveWindow();
			teamsPage.AttachFile();
			teamsPage.SendMessage();
			teamsPage.HardWait();
			actionLogger.Log("Ran out of things to do... Finishing!\n");
	}

	[Test]
	public void WriteAndSendMessageFull()
	{
			teamsPage.LoadTeamsPage();
			teamsPage.LogInTeams();
			teamsPage.FilterPopUps();
			teamsPage.MoveToChat();

			teamsPage.SendFullMessage();
			teamsPage.HardWait();
			actionLogger.Log("Ran out of things to do... Finishing!\n");
	}

	[TearDown]
	public void ChromeTearDown()
	{
		driver.Quit();
	}
}

[TestFixture]
public class TeamsFirefoxTest : CommonTest
{
 	private IWebDriver driver;
	private TeamsPage teamsPage;

	[SetUp]
	public void FirefoxSetup()
	{
		// Get GeckoDriver.exe, initialize the driver and pass it to test page
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string driverPath = Path.GetFullPath(Path.Combine(basePath, "..", "..", "..", "drivers"));

        // Additional code to set cookies preference to "Allow"
        // Avoids stalling out page loading
        FirefoxProfile profile = new FirefoxProfile();
        profile.SetPreference("network.cookie.cookieBehavior", 0);
        FirefoxOptions options = new FirefoxOptions();
        options.Profile = profile;

        // Initiate driver based on parameters
		driver = new FirefoxDriver(driverPath, options);

        // Initiate the Teams page class
		teamsPage = new TeamsPage(driver, actionLogger);
	}

	[Test]
	public void SendMultipleFiles()
	{
			teamsPage.LoadTeamsPage();
			teamsPage.LogInTeams();
			teamsPage.FilterPopUps();
			teamsPage.MoveToChat();
			
			teamsPage.OpenOneDriveWindow();
			teamsPage.AttachFile();
            teamsPage.AttachAnotherFile();
			teamsPage.SendMessage();
			teamsPage.HardWait();
            actionLogger.Log("Ran out of things to do... Finishing!\n");
	}

	[Test]
	public void WriteAndSendMessageFull()
	{
			teamsPage.LoadTeamsPage();
			teamsPage.LogInTeams();
			teamsPage.FilterPopUps();
			teamsPage.MoveToChat();

			teamsPage.SendSplitMessage();
			teamsPage.HardWait();
            actionLogger.Log("Ran out of things to do... Finishing!\n");
	}

	[TearDown]
	public void FirefoxTearDown()
	{
		driver.Quit();
	}
}