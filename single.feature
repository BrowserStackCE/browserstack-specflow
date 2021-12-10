Feature: Google

Scenario Outline: Can find search results
  Given I am on the Bstackdemo website and click on signin
  When I enter "demouser" and "testingisfun99"
  Then I should see user as "demouser"