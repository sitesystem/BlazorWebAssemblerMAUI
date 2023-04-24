using BlazorHybridMAUI.CapaEntities.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorHybridMAUI.CapaServices.BusinessLogic
{
    internal class RickAndMorty : IRickAndMorty
    {
        const string url = "https://rickandmortyapi.com/api/character";

        //public async Task<string> GetPruebaAsync(string texto)
        private readonly HttpClient _httpClient = new HttpClient();

        //public RickAndMorty(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        public async Task<RickAndMortyModel> GetDataAsync()
        {
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var rickAndMorty = JsonSerializer.Deserialize<RickAndMortyModel>(content);

            return rickAndMorty;
        }
    }
}
