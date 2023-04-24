using BlazorWebAssembly.Server.CapaDataAccess.DBContext;
using BlazorWebAssembly.Shared.CapaEntities.ViewModels.Request;
using BlazorWebAssembly.Shared.CapaEntities.ViewModels.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssembly.Server.CapaDataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            Response<List<TbPersona>> oResponse = new Response<List<TbPersona>>();

            try
            {
                using (DbBlazorMauiContext db = new DbBlazorMauiContext())
                {
                    var lst = db.TbPersonas.Where(x => x.IdPersona > 2).ToList();
                    oResponse.Success = 1;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Response<TbPersona> oResponse = new Response<TbPersona>();

            try
            {
                using (DbBlazorMauiContext db = new())
                {
                    var lst = db.TbPersonas.Find(id);
                    oResponse.Success = 1;
                    oResponse.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpPost]
        public IActionResult AddData(TbPersonaViewModel model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (DbBlazorMauiContext db = new())
                {
                    TbPersona oPersona = new();
                    oPersona.IdPersona = model.IdPersona;
                    oPersona.PerNombre = model.PerNombre;
                    oPersona.PerEdad = model.PerEdad;
                    oPersona.PerEmail = model.PerEmail;
                    oPersona.PerFechaAlta = model.PerFechaAlta;
                    db.TbPersonas.Add(oPersona);
                    db.SaveChanges();

                    oResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpPut]
        public IActionResult EditData(TbPersonaViewModel model)
        {
            Response<object> oRespuesta = new();

            try
            {
                using DbBlazorMauiContext db = new();
                TbPersona? oPersona = db.TbPersonas.Find(model.IdPersona);
                oPersona.PerNombre = model.PerNombre;
                oPersona.PerEdad = model.PerEdad;
                oPersona.PerEmail = model.PerEmail;
                oPersona.PerFechaAlta = model.PerFechaAlta;
                db.Entry(oPersona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                oRespuesta.Success = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Message = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteData(int Id)
        {
            Response<object> oRespuesta = new();

            try
            {
                using DbBlazorMauiContext db = new();
                TbPersona? oPersona = db.TbPersonas.Find(Id);
                db.Remove(oPersona);
                db.SaveChanges();

                oRespuesta.Success = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Message = ex.Message;
            }

            return Ok(oRespuesta);
        }
    }
}
