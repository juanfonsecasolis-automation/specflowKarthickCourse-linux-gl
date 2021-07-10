Feature: Pokedex
    In order to be a good Pokemon trainer
    As I am encounting new wild Pokemons
    I want to know how to use the Pokedex API to get information

@pokedex
Scenario: Get a Pokemon
    Given the Pokedex is ON
    When I have entered ID "1" into the Pokedex
    Then the result should return a Pokemon with ID "1"