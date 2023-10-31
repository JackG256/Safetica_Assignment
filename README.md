# Safetica Assignment: Teams web automatisation via Selenium WebDriver

**Project author:** Ladislav Kollár  
**Deadline:** 1. 11. 2023

---
## Files and File Structure

- Folders:
    - `Drivers`: Contains locally accessible web drivers for Chrome and Firefox.
- Files:
    - `AssistFunctions.cs`: Class containing custom helping functions.
    - `BrowserTest.cs`: Inheriting class calling test logic for each browser. Contains tests to run, sets up web drivers, and calls web page logic.
    - `CommonTest.cs`: Parent class to `BrowserTest.cs`, initiates `Logger` classes and logs each test run.
    - `ConstantsValues.cs`: Contains constant values frequently called in tests.
    - `GlobalUsings.cs`: List of imports used globally within the project.
    - `Logger.cs`: Contains the [Logger](./Logger.cs) class with logic for creating log files and directories and logic for logging data into files.

## How to run tests?

1. Clone the git repository to local storage.
2. Build the project in the command line:
    ```
    dotnet build
    ```
3. Run the tests in the command line:
    ```
    dotnet test
    ```

## Where are logs stored?

On the first test run, the logger class creates `test_runs` and `action_logs` folders in the repository root folder (if they don't exist yet).
Logs:
- Test runs and their outcomes are in the `test_runs` folder.
- Detailed logs of actions performed during tests are in the `action_logs` folder.

Each log's name represents the timestamp of its creation.

## Why is half the code in comment blocks?

During the automation process, I encountered challenges in selecting certain dynamic elements with web drivers. 

- Class names with spaces posed difficulties as standard ways of selecting by class with Selenium might be challenging in cases of multiple classes.
- Some elements crucial for testing, specifically the `Attach file` interaction and the `Chatbox input field`, lacked specific IDs or tags. Even XPath-based selection wasn't successful.
- Due to the inability to interact with these two critical elements, some follow-up sections of the code, which are currently commented out, couldn't be ran and  validated. This commented-out code *should* theoretically function correctly with valid element selectors.

## Why does each test end with a sleep delay?

The Teams web application can be slow to load, especially during the transition to the chat section. A delay has been introduced to allow testers and observers to clearly see this transition, as without it, the test would end and running webdriver would close immediately after the `Chat` button is pressed.
