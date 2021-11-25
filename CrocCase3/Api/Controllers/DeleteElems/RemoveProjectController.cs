using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models;
using Services.UseCases.RemoveElem;

namespace Api.Controllers.DeleteElems
{
    [ApiController]
    [Route("RemoveProject")]
    public class RemoveProjectController : ControllerBase
    {
        [HttpPut]
        public SuccessMessage Get(int projectId)
        {
            var projectRemoveService = new RemoveUser();
            var result = projectRemoveService.TryExecute(projectId);
            return result;
        }
    }
}