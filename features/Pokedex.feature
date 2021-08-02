Feature: Pokedex
    In order to catch all Pokemons
    As I am encounting wild Pokemons
    I want to use the Pokedex API to get information about them
    
@pokedex
Scenario: Get a Pokemon
    Given I send a GET request with ID "1" to the Pokedex API
    When the status code is OK
    Then the response returns a Pokemon with ID "1"