using TechTalk.SpecFlow;
using NUnit.Framework;
using karthickSpecflowCourse_linux_gl.models;
using karthickSpecflowCourse_linux_gl.Hooks;
using System.Net;

namespace karthickSpecflowCourse_linux_gl.steps
{
    [Binding]
    public class PokedexSteps : StepsBase
    {
        public Pokedex _pokedex;
        
        public PokedexSteps(SharedSettings sharedSettings) : base(sharedSettings){
            _pokedex = new Pokedex(sharedSettings);
        }

        [Given("the Pokedex is ON")]
        public void GivenThePokedexIsON()
        {
            
        }

        [When("I send a GET request with ID \"(.*)\" to the Pokedex API")]
        public void IHaveEnteredAnIdIntoThePokedex(int id)
        {
            HttpStatusCode statusCode;
            Pokemon pokemon;

            _sharedSettings.expectedValue = id;
            (statusCode, pokemon) = _pokedex.GetPokemonByID(id);
            _sharedSettings.statusCode = statusCode;
            _sharedSettings.currentValue = pokemon.Id;
        }

        [Then("the response returns a Pokemon with ID \"(.*)\"")]
        public void ThenTheResultShouldReturnAPokemonWithID(int id)
        {
            Assert.AreEqual(_sharedSettings.expectedValue,_sharedSettings.currentValue);
        }
    }
}