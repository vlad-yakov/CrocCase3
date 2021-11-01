using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models;
using Services.UseCases.AddElem;

namespace Api.Controllers.AddElems
{
    [ApiController]
    [Route("AddProject")]
    public class AddProjectController : ControllerBase
    {
        private readonly ILogger<AddProjectController> _logger;

        public AddProjectController(ILogger<AddProjectController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        public SuccessMessage Get(string name, int daysPerWeek)
        {
            var project = new ProjectModel
            {
                Name = name,
                DaysPerWeek = daysPerWeek
            };
            var projectAddService = new AddProject();
            var result = projectAddService.TryExecute(project);
            return result;
        }
    }
}