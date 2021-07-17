using Newtonsoft.Json.Linq;
using RestSharp;
//using RestSharp.Serialization.Json;
using System.Text.Json;

namespace karthickSpecflowCourse_linux_gl.models
{
    public class Pokedex
    {
        RestClient _client;

        public Pokedex(string pokeapiUrl){
            _client = new RestClient(pokeapiUrl);
        }

        public (int, Pokemon) GetPokemonByID(int pokemonID){
            var request = new RestRequest("api/v2/pokemon/{pokemonID}", Method.GET);
            request.AddUrlSegment("pokemonID", pokemonID);
            var response = _client.Execute(request);
            return ((int) response.StatusCode, 
                JsonSerializer.Deserialize<Pokemon>(response.Content));
        }
    }
}