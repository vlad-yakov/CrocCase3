using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models;
using Services.UseCases.AddElem;

namespace Api.Controllers.AddElems
{
    [ApiController]
    [Route("AddEvent")]
    public class AddEventController : ControllerBase
    {
        private readonly ILogger<AddEventController> _logger;

        public AddEventController(ILogger<AddEventController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        public SuccessMessage Get(string name, string weekDay)
        {
            var eventElem = new EventModel
            {
                Name = name,
                WeekDay = weekDay
            };
            var eventAddService = new AddEvent();
            var result = eventAddService.TryExecute(eventElem);
            return result;
        }
    }
}