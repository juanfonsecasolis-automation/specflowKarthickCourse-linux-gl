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
        Pokemon _pokemon;
        
        public PokedexSteps(SharedSettings sharedSettings, ScenarioContext scenarioContext) : base(sharedSettings, scenarioContext){
            _pokedex = new Pokedex(sharedSettings);
        }

        [Given("I send a GET request with ID \"(.*)\" to the Pokedex API")]
        public void ISendAGetResquestWithIdToThePokedexApi(int id)
        {
            _scenarioContext[Keys.expectedValue] = id;
            (_scenarioContext[Keys.statusCode], _pokemon) = _pokedex.GetPokemonByID(id);
            _scenarioContext[Keys.currentValue] = _pokemon.Id;
        }

        [Then("the response returns a Pokemon with ID \"(.*)\"")]
        public void ThenTheResultShouldReturnAPokemonWithID(int id)
        {
            Assert.AreEqual(_scenarioContext[Keys.expectedValue],_scenarioContext[Keys.currentValue]);
        }
    }
}