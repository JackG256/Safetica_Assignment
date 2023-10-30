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
        var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
        var driverPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(basePath, "..", "..", "..", "drivers"));

		driver = new ChromeDriver(driverPath);

		teamsPage = new TeamsPage(driver, actionLogger);
	}

	[Test]
	public void SendOneDriveFile()
	{
			teamsPage.LoadTeamsPage();
			teamsPage.LogInTeams();
			teamsPage.FilterPopUps();
			teamsPage.MoveToChat();
			//_teamsPage.OpenOneDriveWindow();


			//_teamsPage.HardWait();
	}

	//[Test]
	//public void LoadPageAndLogIn()
	//{
	//		Assert.Pass();
	//}

	[TearDown]
	public void ChromeTearDown()
	{
		driver.Quit();
	}
}