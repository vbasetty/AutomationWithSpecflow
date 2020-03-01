Feature: Checking Login Button existance on the page

@Home
Scenario: Login In Link Exists
   Given I have navigated to UBS site
   When the Home page loads on the browser
   Then the login In link appears on the Home page

