Feature: Reqres
    Learn how to use Reqres

Background:
    Given I invoke a GET request on the /users endpoint

@reqres
Scenario: TC8: verify pagination works
    When the status code is OK
    Then the number of records matches the property "per_page"
