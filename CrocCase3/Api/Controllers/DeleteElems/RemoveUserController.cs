using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models;
using Services.UseCases.RemoveElem;

namespace Api.Controllers.DeleteElems
{
    [ApiController]
    [Route("RemoveUser")]
    public class RemoveUserController : ControllerBase
    {
        private readonly ILogger<RemoveUserController> _logger;

        public RemoveUserController(ILogger<RemoveUserController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        public SuccessMessage Get(int userId)
        {
            var userRemoveService = new RemoveUser();
            var result = userRemoveService.TryExecute(userId);
            return result;
        }
    }
}