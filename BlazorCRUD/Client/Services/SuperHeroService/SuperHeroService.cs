using BlazorCRUD.Shared.Models;
using System.Net.Http.Json;

namespace BlazorCRUD.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _httpClient;
        public SuperHeroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<SuperHero> Heroes { get; set ; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public async Task GetComics()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
            if (result != null)
            {
                Comics = result;
            }
         }

        public async Task<SuperHero> GetSingleHero(int id)
        {

            var result = await _httpClient.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
            if (result != null)
            {
               return result;
            }
            throw new Exception("Hero Not Found");
        }

        public async Task GetSuperHeroes()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            if(result!=null)
            {
                Heroes = result;
            }
        }
    }
}
