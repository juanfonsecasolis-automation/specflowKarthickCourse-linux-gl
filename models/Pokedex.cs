using karthickSpecflowCourse_linux_gl.Hooks;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace karthickSpecflowCourse_linux_gl.models
{
    public class Pokedex : APIHandler
    {
        public Pokedex(SharedSettings sharedSettings)
            :base(sharedSettings.config["pokeapiUrl"]){}

        public (HttpStatusCode, Pokemon) GetPokemonByID(int pokemonID){
            HttpStatusCode statusCode; 
            JObject jObject; 
            (statusCode, jObject) = ExecuteGetRequest($"api/v2/pokemon/{pokemonID}");
            return (statusCode,jObject.ToObject<Pokemon>());
        }
    }
}