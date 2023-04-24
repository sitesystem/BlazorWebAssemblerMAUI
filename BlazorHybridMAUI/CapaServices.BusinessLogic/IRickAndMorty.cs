using BlazorHybridMAUI.CapaEntities.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridMAUI.CapaServices.BusinessLogic
{
    internal interface IRickAndMorty
    {
        public Task<RickAndMortyModel> GetDataAsync();
    }
}
