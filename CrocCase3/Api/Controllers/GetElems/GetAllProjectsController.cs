using System.Collections.Generic;
using DataModel.Models;
using DataModel.Models.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.UseCases.GetElem;

namespace Api.Controllers.DeleteElems
{
    [ApiController]
    [Route("GetAllProjects")]
    public class GetAllProjectsController : ControllerBase
    {
        private readonly ILogger<GetAllProjectsController> _logger;

        public GetAllProjectsController(ILogger<GetAllProjectsController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        public IEnumerable<ProjectModel> Get()
        {
            var getAllProjectsController = new GetAllProjects();
            var result = getAllProjectsController.TryExecute();
            return result;
        }
    }
}