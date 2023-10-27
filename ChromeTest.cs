using Safetica_Assignment.PageObjects;

namespace Safetica_Assignment;

[TestFixture]
public class TeamsChromeTests : CommonTest
{
 	private IWebDriver _driver;
	private TeamsPage _teamsPage;

	[SetUp]
	public void ChromeSetup()
	{
		// Get Chromedriver.exe, initialize the driver and pass it to test page
        var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
        var driverPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(basePath, "..", "..", "..", "drivers"));

		_driver = new ChromeDriver(driverPath);

		_teamsPage = new TeamsPage(_driver, _actionLogger);
	}

	[Test]
	public void SendOneDriveFile()
	{
			_teamsPage.LoadTeamsPage();
			_teamsPage.LogInTeams();
			_teamsPage.FilterPopUps();
	}

	//[Test]
	//public void LoadPageAndLogIn()
	//{
	//		Assert.Pass();
	//}

	[TearDown]
	public void ChromeTearDown()
	{
		_driver.Quit();
	}
}