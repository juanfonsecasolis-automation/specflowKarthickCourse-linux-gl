Feature: Reqres
Learn how to use Reqres

@reqres
Scenario: verify pagination works
    Given I invoke a GET request on Reqres
    When I count the number of people returned
    Then the counter matches with property "per_page"

