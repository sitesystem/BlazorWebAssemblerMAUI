using BlazorHybridMAUI.CapaEntities.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorHybridMAUI.CapaEntities.ViewModels.Request;

namespace BlazorHybridMAUI.CapaServices.BusinessLogic
{
    public class RPersona : IPersona
    {
        const string url = "https://localhost:7002/api/Personas";

        private readonly HttpClient _httpClient = new();

        public RPersona() { }

        public async Task<Response<List<TbPersonaViewModel>>> GetDataAsync()
        {
            //var response = await _httpClient.GetAsync(url);
            //var content = await response.Content.ReadAsStringAsync();
            //var result = JsonSerializer.Deserialize<Response<List<TbPersonaViewModel>>>(content,
            //    new JsonSerializerOptions()
            //    {
            //        PropertyNameCaseInsensitive = true
            //    });

            var result = await _httpClient.GetFromJsonAsync<Response<List<TbPersonaViewModel>>>(url,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

            return result;
        }

        public async Task<Response<TbPersonaViewModel>> GetDataByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(url + "/" + id);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Response<TbPersonaViewModel>>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

            return result;
        }

        public async Task<HttpResponseMessage> AddDataAsync(TbPersonaViewModel oPersona)
        {
            var json = JsonSerializer.Serialize(oPersona);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            return response;
        }

        public async Task<HttpResponseMessage> EditDataAsync(TbPersonaViewModel oPersona)
        {
            var json = JsonSerializer.Serialize(oPersona);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);

            return response;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(url + "/" + id);

            return response;
        }
    }
}
