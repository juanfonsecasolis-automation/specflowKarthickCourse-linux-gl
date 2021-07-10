using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace karthickSpecflowCourse_linux_gl.steps
{
    [Binding]
    public class PokedexSteps : StepsBase
    {
        int pokemonID;
        string valueCurrent;

        [Given("the Pokedex is ON")]
        public void GivenThePokedexIsON()
        {
            
        }

        [When("I have entered ID \"(.*)\" into the Pokedex")]
        public void IHaveEnteredAnIdIntoThePokedex(int id)
        {
            int offset = int.Parse(config["offset"]);
            pokemonID = offset + 1;

            var client = new RestClient("https://pokeapi.co/");
            var request = new RestRequest("api/v2/pokemon/{pokemonID}", Method.GET);
            request.AddUrlSegment("pokemonID", pokemonID);

            var response = client.Execute(request);
            System.Console.WriteLine($"Result: {response.Content}");

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            valueCurrent = output["id"];
        }

        [Then("the result should return a Pokemon with ID \"(.*)\"")]
        public void ThenTheResultShouldReturnAPokemonWithID(int id)
        {
            Assert.AreEqual(valueCurrent, $"{pokemonID}", "ID is not correct.");
        }
    }
}