using BlazorWebAssembly.Shared.CapaEntities.ViewModels.Request;
using BlazorWebAssembly.Shared.CapaEntities.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Shared.CapaServices.BusinessLogic.ClientServices
{
    public class RPersona : IPersona
    {
        //const string url = "https://localhost:7002/api/Personas";

        private readonly HttpClient _httpClient;

        public RPersona(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<List<TbPersonaViewModel>>> GetDataAsync(string path)
        {
            var response = await _httpClient.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Response<List<TbPersonaViewModel>>>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

            //var result = await _httpClient.GetFromJsonAsync<Response<List<TbPersona>>>(path,
            //new JsonSerializerOptions()
            //{
            //    PropertyNameCaseInsensitive = true
            //});

            return result;
        }

        public async Task<Response<TbPersonaViewModel>> GetDataByIdAsync(int id)
        {
            //var response = await _httpClient.GetAsync("/api/Personas/" + id);
            //var content = await response.Content.ReadAsStringAsync();
            //var result = JsonSerializer.Deserialize<Response<TbPersona>>(content,
            //    new JsonSerializerOptions()
            //    {
            //        PropertyNameCaseInsensitive = true
            //    });

            var result = await _httpClient.GetFromJsonAsync<Response<TbPersonaViewModel>>("/api/Personas/" + id,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

            return result;
        }

        public async Task<HttpResponseMessage> AddDataAsync(string path, TbPersonaViewModel oPersona)
        {
            var json = JsonSerializer.Serialize(oPersona);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(path, content);

            //var response = await _httpClient.PostAsJsonAsync<TbPersona>(path, oPersona,
            //    new JsonSerializerOptions()
            //    {
            //        PropertyNameCaseInsensitive = true
            //    });

            return response;
        }

        public async Task<HttpResponseMessage> EditDataAsync(string path, TbPersonaViewModel oPersona)
        {
            //var json = JsonSerializer.Serialize(oPersona);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await _httpClient.PutAsync(path, content);

            var response = await _httpClient.PutAsJsonAsync<TbPersonaViewModel>(path, oPersona,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

            return response;
        }

        public async Task<HttpResponseMessage> DeleteDataAsync(string path, int id)
        {
            var response = await _httpClient.DeleteAsync(path + "/" + id);

            return response;
        }
    }
}
