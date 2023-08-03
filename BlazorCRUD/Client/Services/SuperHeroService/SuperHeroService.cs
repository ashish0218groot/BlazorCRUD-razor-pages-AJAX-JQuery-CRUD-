using BlazorCRUD.Client.Pages;
using BlazorCRUD.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCRUD.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public SuperHeroService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public async Task CreateSuperHero(SuperHero superHero)
        {
            var result = await _httpClient.PostAsJsonAsync("api/superhero", superHero);
            await SetHeroesList(result);
        }

        private async Task SetHeroesList(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            Heroes = response;
            _navigationManager.NavigateTo("superheroes");
         }

        public async Task DeleteSuperHero(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/superhero/{id}");
             await SetHeroesList(result);
        }

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
            if (result != null)
            {
                Heroes = result;
            }
        }

        public async Task UpdateSuperHero(SuperHero superHero)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/superhero/{superHero.Id}", superHero);
            //var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            await SetHeroesList(result);
        }
    }
}
