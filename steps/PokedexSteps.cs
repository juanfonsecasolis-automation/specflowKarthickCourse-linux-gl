using TechTalk.SpecFlow;
using NUnit.Framework;
using karthickSpecflowCourse_linux_gl.models;
using System.Net;

namespace karthickSpecflowCourse_linux_gl.steps
{
    [Binding]
    public class PokedexSteps : StepsBase
    {
        Pokedex _pokedex;

        [Given("the Pokedex is ON")]
        public void GivenThePokedexIsON()
        {
            _pokedex = new Pokedex(config["pokeapiUrl"]);
        }

        [When("I enter ID \"(.*)\" in the Pokedex API")]
        public void IHaveEnteredAnIdIntoThePokedex(int id)
        {
            _bag[BagItems.expectedValue] = id;
            TestContext.WriteLine($"Expected: {id}");

            HttpStatusCode statusCode;
            Pokemon pokemon;
            (statusCode, pokemon) = _pokedex.GetPokemonByID(id);

            Assert.AreEqual(HttpStatusCode.OK, statusCode);

            _bag[BagItems.currentValue] = pokemon.Id;
        }

        [Then("the response returns a Pokemon with ID \"(.*)\"")]
        public void ThenTheResultShouldReturnAPokemonWithID(int id)
        {
            Assert.AreEqual(
                (int)_bag[BagItems.expectedValue],
                (int)_bag[BagItems.currentValue]+1);
        }
    }
}