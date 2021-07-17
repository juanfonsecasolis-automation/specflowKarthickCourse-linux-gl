using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using karthickSpecflowCourse_linux_gl.models;
using Newtonsoft.Json.Linq;

namespace karthickSpecflowCourse_linux_gl.steps
{
    [Binding]
    public class PokedexSteps : StepsBase
    {
        Bag _bag;
        Pokedex _pokedex;

        [Given("the Pokedex is ON")]
        public void GivenThePokedexIsON()
        {
            _pokedex = new Pokedex(config["pokeapiUrl"]);
            _bag = new Bag();
        }

        [When("I enter ID \"(.*)\" in the Pokedex API")]
        public void IHaveEnteredAnIdIntoThePokedex(int id)
        {
            _bag[Items.expectedValue] = (int.Parse(config["offset"]) + 1).ToString();

            int statusCode;
            Pokemon pokemon;
            (statusCode, pokemon) = _pokedex.GetPokemonByID(
                int.Parse(_bag[Items.expectedValue])
            );

            Assert.AreEqual(statusCode,200, $"Request failed with code {statusCode}");

            _bag[Items.currentValue] = pokemon.Id.ToString();
        }

        [Then("the response returns a Pokemon with ID \"(.*)\"")]
        public void ThenTheResultShouldReturnAPokemonWithID(int id)
        {
            Assert.AreEqual(_bag[Items.currentValue], 
                $"{_bag[Items.expectedValue]}", "ID is not correct.");
        }
    }
}