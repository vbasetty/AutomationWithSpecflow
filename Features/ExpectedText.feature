Feature: Validating whether the web page contains the defined text

@Home
Scenario: Defined Text Exists on the web page
   Given I have navigated to web page
   When the Home page loads in the browser
   Then the defined text should be visible on the Home page
