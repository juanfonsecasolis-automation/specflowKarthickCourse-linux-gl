Feature: ReqresPost
    Learn how to use Reqres POST, PUT, PATCH requests

@reqres
Scenario: TC11: Verify users can be created
    Given I create a new user with name "csharp_user" and job "tester"
    When the status code is "201"
    Then the response contains a non-null field "name" for user "0"

#@reqres
#Scenario: TC12: Verify that users can be partially updated (PATCH)
#    Given I update user with ID "0" with name "jfonseca_reloaded_test"
#    When the status code is "200"
#    Then user has indeed name to the name provided

@reqres @ignore
Scenario: TC14: Verify users can be deleted
    Given the last created user still exists
    When I delete the last created user
    Then the status code is "204"