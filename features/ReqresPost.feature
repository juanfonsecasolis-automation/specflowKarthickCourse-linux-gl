Feature: ReqresPost
    Learn how to use Reqres POST, PUT, PATCH requests

@reqres
Scenario: TC11: Verify users can be created
    Given I send a Post request to create a new user with name "csharp_test" and job "tester"
    When the status code is "201"
    Then the response contains a non-null field "name" for user "0"

@reqres
Scenario: TC14: Verify users can be deleted
    Given I delete the last created user
    When the status code is "204"
    # no then