using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridMAUI.CapaEntities.ViewModels.Response
{
    public class Response<T>
    {
        public int Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Response()
        {
            Success = 0;
        }
    }
}
