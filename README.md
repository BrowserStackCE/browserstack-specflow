![BrowserStack Logo](https://camo.githubusercontent.com/09765325129b9ca76d770b128dbe30665379b7f2915d9b60bf57fc44d9920305/68747470733a2f2f7777772e62726f77736572737461636b2e636f6d2f696d616765732f7374617469632f6865616465722d6c6f676f2e6a7067)


# BrowserStack Example - Specflow Script

Sample test case to demonstrate integration of a Specflow test on BrowserStack.

## Pre-requisites

* Identify your BrowserStack username and access key from the [BrowserStack Automate Dashboard](https://automate.browserstack.com/) and export them as environment variables using the below commands. 
  - For *nix based and Mac machines:
      ```
      export BROWSERSTACK_USERNAME=<browserstack-username> &&
      export BROWSERSTACK_ACCESS_KEY=<browserstack-access-key>
      ```
  - For Windows:
      ```
      set BROWSERSTACK_USERNAME=<browserstack-username>
      set BROWSERSTACK_ACCESS_KEY=<browserstack-access-key>
      ```
* You can view your test results on the [BrowserStack Automate dashboard](https://www.browserstack.com/automate)
* To test on a different set of browsers, check out our [platform configurator](https://www.browserstack.com/docs/automate/selenium/select-browsers-and-devices)

## Steps to run
- Restore Nuget packages - `dotnet restore`
- Build the project - `dotnet msbuild`
- Run the test - `dotnet test`