using Microsoft.AspNetCore.Mvc;
using ProspectionConfig;
using Prospection.Models.Bpm;
using Prospection.Models.DTO;
using Prospection.Models.Request;
using Prospection.Models.Response;
using Prospection.Repositories.v1;

namespace Prospection.Api.Controllers.v1
{
    [Route("api/form")]
    [ApiController]
    public class FormulariosController : ControllerBase
    {
        private readonly FormRepository _service;

        public FormulariosController(FormRepository service)
        {
            _service = service;
        }

        [HttpGet("GetFormByName")]
        public async Task<List<Forms>> GetFormByName(string formName)
        {
            return await Task.Run(() => _service.GetFormByName(formName));
        }

        [HttpGet("GetFormByFormId")]
        public async Task<List<Forms>> GetFormByFormId(string formId)
        {
            return await Task.Run(() => _service.GetFormByFormId(formId));
        }

        [HttpGet("GetFormsByFuncionallity")]
        public async Task<List<Forms>> GetFormsByFuncionallity(string funcionality)
        {
            return await Task.Run(() => _service.GetFormsByFuncionallity(funcionality));
        }

        [HttpPost("GetGridBody")]
        public async Task<string> GetGridBody(GridBodyModel gridBodyModel)
        {
            return await Task.Run(() => _service.GetGridBody(gridBodyModel));
        }

        [HttpPost("Submit")]
        public async Task<List<ApiResponse>> Submit(Submit submit)
        {
            return await Task.Run(() => _service.Submit(submit));
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
