Evolving Functional Test Framework (Selenium & .Net)
==================================================

The objective of this repository is to demonstrate the evolution of functional test automation framework.
Each commit in the repository represents a change leading towards evolution

Please follow the Steps below to get the tests running on your local machine:

Pre-Requisites:
------------------
   * Install Visual Studio Express 2013
   * Install Chrome browser or update to Latest version

Steps:
-------
   * Clone this repository
   * Open the solution
   * Rebuild
   * Open your test assembly's properties. For example, right-click on the assembly and select Properties. On the Application tab, select Output Type: Windows Application; and Startup Object: NUNitConolseRunner. On the Debug tab, enter the .csproj file name in Command Line Arguments; and browse to the folder of the .csproj file in Working Directory. Save everything. (This step is needed to execute tests within Visual Studio)
   * Run tests using F5 or the green arrow button.



Commit Descriptions:
---------------------------------------------
Below is the brief description of commits. Each commit has a significance role in evolving the framework. More detailed version would be available soon as a git book...


Chapter1: Adding First Test
---------------------------------------------

This is the first commit where in project is checked in along with first test test.


Chapter2: Adding Second Test
---------------------------------------------

Adding second test. Now Observe the duplication of code


Chapter3: Introducing Setup & Teardown
---------------------------------------------
Introducing Setup and Teardown to reduce the code duplication


Chapter4: Adding Second TestFixture Logout tests
---------------------------------------------
Add 2nd test class. Observe the code duplication across 2 test classes.


Chapter5: Introducing TestBase
---------------------------------------------
Move the common code to base class to avoid the duplication. Observe Login function also got moved to base class


Chapter6: Adding Client Tests
---------------------------------------------
Adding 3rd test class. Adding couple of tests. Observe the code 


Chapter7: Moving Add New Client method to TestBase
---------------------------------------------

Extracting AddNewClient method and moving it to base class so that its available to all test classes


Chapter8: Introducing DriverProvider
---------------------------------------------

Saving a reference of driver instance. This reference would be used going forward everywhere


Chapter9: Introducing Pages and SignInPage
---------------------------------------------

Moving Code away from TestBase and adding it to corrosponding Page classes



Chapter10: Adding AddNewClientPage
---------------------------------------------
Moving Code away from TestBase and adding it to corrosponding Page classes

Thus arriving at Page-Object Model


Chapter11: Introducing Entities
---------------------------------------------

Creating Client Entity to manage test data readable and managable 


Chapter12: Handling Assertion failures and exceptions
---------------------------------------------

Easing maintenance. Capturing screenshots, html source when test fails due to exceptions and/or assertion failures 


Chapter13: Externalize test configuration
---------------------------------------------

Externalizing configuration details

