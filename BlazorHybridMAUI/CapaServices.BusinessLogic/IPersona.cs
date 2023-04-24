using BlazorHybridMAUI.CapaEntities.ViewModels.Request;
using BlazorHybridMAUI.CapaEntities.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridMAUI.CapaServices.BusinessLogic
{
    public interface IPersona
    {
        public Task<Response<List<TbPersonaViewModel>>> GetDataAsync();
        public Task<Response<TbPersonaViewModel>> GetDataByIdAsync(int Id);
        public Task<HttpResponseMessage> AddDataAsync(TbPersonaViewModel oPersona);
        public Task<HttpResponseMessage> EditDataAsync(TbPersonaViewModel oPersona);
        public Task<HttpResponseMessage> DeleteDataAsync(int id);
    }
}
