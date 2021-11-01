using System.Collections.Generic;
using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.UseCases.GetElem;

namespace Api.Controllers.DeleteElems
{
    [ApiController]
    [Route("GetAllUsers")]
    public class GetAllUsersController : ControllerBase
    {
        private readonly ILogger<GetAllUsersController> _logger;

        public GetAllUsersController(ILogger<GetAllUsersController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        public IEnumerable<UserModel> Get()
        {
            var getAllUsersController = new GetAllUsers();
            var result = getAllUsersController.TryExecute();
            return result;
        }
    }
}