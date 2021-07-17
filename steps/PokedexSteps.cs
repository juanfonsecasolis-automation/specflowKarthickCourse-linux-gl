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
        int pokemonID;
        string valueCurrent;
        Pokedex _pokedex;

        [Given("the Pokedex is ON")]
        public void GivenThePokedexIsON()
        {
            _pokedex = new Pokedex();
        }

        [When("I enter ID \"(.*)\" in the Pokedex API")]
        public void IHaveEnteredAnIdIntoThePokedex(int id)
        {
            int pokemonID = int.Parse(config["offset"]) + 1;

            int statusCode;
            Pokemon pokemon;
            (statusCode, pokemon) = _pokedex.GetPokemonByID(pokemonID);

            Assert.AreEqual(statusCode,200, $"Request failed with code {statusCode}");

            valueCurrent = pokemon.Id.ToString();
        }

        [Then("the response returns a Pokemon with ID \"(.*)\"")]
        public void ThenTheResultShouldReturnAPokemonWithID(int id)
        {
            Assert.AreEqual(valueCurrent, $"{pokemonID}", "ID is not correct.");
        }
    }
}