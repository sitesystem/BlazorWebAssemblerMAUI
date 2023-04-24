using BlazorWebAssembly.Shared.CapaEntities.ViewModels.Request;
using BlazorWebAssembly.Shared.CapaEntities.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Shared.CapaServices.BusinessLogic.ClientServices
{
    public interface IPersona
    {
        public Task<Response<List<TbPersonaViewModel>>> GetDataAsync(string path);
        public Task<Response<TbPersonaViewModel>> GetDataByIdAsync(int Id);
        public Task<HttpResponseMessage> AddDataAsync(string path, TbPersonaViewModel persona);
        public Task<HttpResponseMessage> EditDataAsync(string path, TbPersonaViewModel persona);
        public Task<HttpResponseMessage> DeleteDataAsync(string path, int id);
    }
}
