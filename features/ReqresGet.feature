Feature: ReqresGet
    Learn how to use Reqres GET requests

Background:
    Given I get the information of user "1"

@reqres
Scenario: TC8: verify pagination works
    When the status code is "200"
    Then the number of records matches the property "per_page"

@reqres
Scenario: TC9: verify mandatory personal information fields are present
    When the status code is "200"
    Then the response contains a non-null field "id" for user "0"
    And the response contains a non-null field "email" for user "0"
    And the response contains a non-null field "first_name" for user "0"
    And the response contains a non-null field "last_name" for user "0"
    And the response contains a non-null field "avatar" for user "0"

@reqres
Scenario: TC10: Verify that the each email follows the format "name@domain.ext"
    When the status code is "200"
    Then "email" field in response follows regex "[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-z]+" for user "0"