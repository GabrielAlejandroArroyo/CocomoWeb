using Microsoft.AspNetCore.Mvc;
using Prospection.Models.DTO;
using Prospection.Repositories.v1;


namespace Prospection.Api.Controllers.v1
{

    [Route("api/bpm")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {

        private readonly WorkFlowRepository _service;

        public WorkFlowController(WorkFlowRepository service)
        {
            _service = service;
        }

        [HttpGet("GetWorkflowByName")]
        public async Task<List<ConfigDTO>> GetWorkflowByName(string name)
        {
            return await Task.Run(() => _service.GetWorkflowByName(name));
        }

    }
}
