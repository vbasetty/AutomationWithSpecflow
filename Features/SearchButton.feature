Feature: Checking Search button Existence and its functionality

@Search
Scenario: Search button exists and accepts strings and displays the associated page
   Given I have navigated to UBS
   And I have clicked on the search button
   When the Header search opens
   And I have entered the Home string
   And I have clicked on search button again
   Then the associated page displays
