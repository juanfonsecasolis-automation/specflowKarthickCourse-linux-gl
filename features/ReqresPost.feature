Feature: ReqresPost
    Learn how to use Reqres POST, PUT, PATCH requests

@reqres
Scenario: TC11: Verify users can be created
    Given I create a new user with name "csharp_user" and job "tester"
    When the status code is "201"
    Then the response contains a non-null field "name" for user "0"

@reqres @ignore
Scenario: TC14: Verify users can be deleted
    Given the last created user still exists
    When I delete the last created user
    Then the status code is "204"