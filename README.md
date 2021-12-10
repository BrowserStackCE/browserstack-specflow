## BrowserStack Specflow Sample

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
- Build the project - `dotnet msbuild`
- Run the test - `dotnet test`