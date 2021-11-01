using System.Collections.Generic;
using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.UseCases.GetElem;

namespace Api.Controllers.DeleteElems
{
    [ApiController]
    [Route("GetAllEvents")]
    public class GetAllEventsController : ControllerBase
    {
        private readonly ILogger<GetAllEventsController> _logger;

        public GetAllEventsController(ILogger<GetAllEventsController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        public IEnumerable<EventModel> Get()
        {
            var getAllEventsService = new GetAllEvents();
            var result = getAllEventsService.TryExecute();
            return result;
        }
    }
}