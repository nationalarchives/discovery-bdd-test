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

	- Download it locally in the path C:\\chromedriver-83.0\\  
	- Update the 12 "appsettings.json" files to set "googleDriverPath": "C:\\chromedriver-83.0\\". Just do a find and replace.
	
      NOTE: Ensure the chromedriver version is compatible with the local Chrome browser version
 
 - you can change the url of the discovery to ctest or cdev or test- in "appsettings.json" file for individual projects. For every project there is a appsettings.json file.
 - Run or debug the tests 
 - For Ecommerce tests I have included two sample images- Can you download 2 sample jpg images and save them locally in the following path 
           "Image1Path": "C:\\temp\\test-img\\Koala.jpg",
           "Image2Path": "C:\\temp\\test-img\\Sample-500kb.jpg"
	   
 - For SSO tests we have 3 test gmail accounts, the user name and passwords are as below
   gmail account1: tnatest595@gmail.com ,  Password: Test123456@
  gmail account2 : tnadiscovery100@gmail.com , password : Discovery12345
  gmail account3 : discoveryt32@gmail.com, password : Test123456@
  
  - Under SSO tests under RegisterPageFeature - Run the first 2 tests and verify the email manually by logging into 
  gmail account : discoveryt32@gmail.com, password : Test123456@
  Then run the remaining SSO tests.
   - FYI SSO log in "username": "tnadiscovery100@gmail.com", "password": "Test123456"

### Method2: 
 - open the command prompt
	
		  $ cd  pathOfTheProject
 
		  $dotnet test  
	
 - Then you can able to run your tests without opening visual studio


## Post test cleanup
If running the tests leaves multiple Chrome windows open run these commands on an elevate command prompt to close the windows
 - taskkill /IM chrome.exe /F
 - taskkill /IM chromedriver.exe /F
