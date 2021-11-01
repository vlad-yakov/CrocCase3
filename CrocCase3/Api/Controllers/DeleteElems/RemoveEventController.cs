using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models;
using Services.UseCases.RemoveElem;

namespace Api.Controllers.DeleteElems
{
    [ApiController]
    [Route("RemoveEvent")]
    public class RemoveEventController : ControllerBase
    {
        private readonly ILogger<RemoveEventController> _logger;

        public RemoveEventController(ILogger<RemoveEventController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        public SuccessMessage Get(int eventId)
        {
            var eventRemoveService = new RemoveEvent();
            var result = eventRemoveService.TryExecute(eventId);
            return result;
        }
    }
}