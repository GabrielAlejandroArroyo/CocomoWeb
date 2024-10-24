using Microsoft.AspNetCore.Mvc;
using Prospection.Models.Bpm;
using Prospection.Repositories.v1;

namespace Prospection.Api.Controllers.v1
{

    [Route("api/repo")]
    [ApiController]
    public class RportesController : ControllerBase
    {
        private readonly RepoRepository _service;

        public RportesController(RepoRepository service)
        {
            _service = service;
        }

        [HttpGet("GetDefinitionByDashboard")]
        public async Task<Definition> GetDefinitionByDashboard(string dashboard)
        {
            return await Task.Run(() => _service.GetDefinitionByDashboard(dashboard));
        }

        [HttpGet("GetDashboards")]
        public async Task<string> GetDashboards()
        {
            return await Task.Run(() => _service.GetDashboards());
        }

        [HttpGet("ExecSubQuery")]
        public async Task<string> ExecSubQuery(string dashboard, string query)
        {
            return await Task.Run(() => _service.ExecSubQuery(dashboard, query));
        }

        [HttpGet("ExecSubQueryParams")]
        public async Task<string> ExecSubQueryParams(string dashboard, string query, string where)
        {
            return await Task.Run(() => _service.ExecSubQueryParams(dashboard, query, where));
        }

        [HttpGet("GetFilters")]
        public async Task<Definition> GetFilters(string dashboard, string filtername)
        {
            return await Task.Run(() => _service.GetFilters(dashboard, filtername));
        }
    }
}
