Feature: Pokedex
    In order to catch all Pokemons
    As I am encounting wild Pokemons
    I want to use the Pokedex API to get information about them

@pokedex
Scenario: Get a Pokemon
    Given the Pokedex is ON
    When I send a GET request with ID "1" to the Pokedex API
    Then the status code is OK
    And the response returns a Pokemon with ID "1"