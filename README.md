# discovery-bdd-test
External user acceptance testing
This repository provides running tests on discovery website

It currently run tests against the Chrome browser only.

## Running Tests Locally

you need to clone the project 

## There are 2 methods to run the tests
### Method1: 
 - open the sln file with visual studio.
 - Ensure that the Chrome browser is available locally
 - Download and unzip chromedriver locally: https://chromedriver.chromium.org/downloads
	- you need to copy this location of chrome driver and paste it "appsettings.json" file
	
      NOTE: Ensure the chromedriver version is compatible with the local Chrome browser version
 
 - you can change the url of the discovery to ctest or cdev or test- in "appsettings.json" file.
 - Run or debug the tests 

### Method2: 
 - open the command prompt
	
		  $ cd  pathOfTheProject
 
		  $dotnet test  
	
 - Then you can able to run your tests without opening visual studio
