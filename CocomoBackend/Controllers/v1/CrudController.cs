using Microsoft.AspNetCore.Mvc;
using ProspectionConfig;
using Prospection.Models.Bpm;
using Prospection.Models.DTO;
using Prospection.Models.Request;
using Prospection.Models.Response;
using Prospection.Services.Repositories.v1;

namespace Prospection.Api.Controllers.v1
{

    [Route("api/crud")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly CrudRepository _service;

        public CrudController(CrudRepository service)
        {
            _service = service;
        }

        [HttpGet("GetFormByFormId")]
        public async Task<List<Forms>> GetFormByFormId(string formId)
        {
            return await Task.Run(() => _service.GetFormByFormId(formId));
        }

        [HttpGet("GetGridBody")]
        public async Task<string> GetGridBody(string table, string condicion = "")
        {
            return await Task.Run(() => _service.GetGridBody(table, condicion));
        }

        [HttpPost("Create")]
        public async Task<bool> Create(SubmitCrud submit)
        {
            return await Task.Run(() => _service.Create(submit));
        }

        [HttpPost("Update")]
        public async Task<bool> Update(SubmitCrud submit)
        {
            return await Task.Run(() => _service.Update(submit));
        }

        [HttpPost("Delete")]
        public async Task<bool> Delete(SubmitCrud submit)
        {
            return await Task.Run(() => _service.Delete(submit));
        }

        [HttpGet("GetCatalogos")]
        public async Task<List<CatalogoDTO>> GetCatalogos(string ctg)
        {
            return await Task.Run(() => _service.GetCatalogos(ctg));
        }

        [HttpPost("GetEvent")]
        public async Task<EventStatus> GetEvent(EventDTO evento)
        {
            return await Task.Run(() => Config.GetEvent(evento));
        }


    }
}
