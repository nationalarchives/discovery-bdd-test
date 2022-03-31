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
	- Download it locally in the path C:\\chromedriver-[version]\\  (this is referred to in "appsettings.json" files - see below)
	- [version] should be replaced with the actual version number downloaded e.g. C:\\chromedriver-87.0\\ . 
	- NOTE: Ensure the chromedriver version is compatible with the local Chrome browser version. As of this update, chromedriver version numbers match the latest 			chrome version numbers, e.g. 87.0 for Chrome v.87 and 88.0 for Chrome v.88.  Check https://chromedriver.chromium.org/downloads for the latest 				information.
	- the chromedriver file location is also referenced in the appsetings.json files for various projects via the googDriverPath element.  You need to ensure this 			refers to the correct path.  E.g. "googleDriverPath": "C:\\chromedriver-87.0\\",
 
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
 
 The tests open Chrome for every test and some (a lot) remain open after testing. To close these windows run these commands -
 taskkill /IM chrome.exe /F
 taskkill /IM chromedriver.exe /F
