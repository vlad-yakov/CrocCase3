using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models;
using Services.UseCases.AddElem;

namespace Api.Controllers.AddElems
{
    [ApiController]
    [Route("AddUser")]
    public class AddUserController : ControllerBase
    {
        private readonly ILogger<AddUserController> _logger;

        public AddUserController(ILogger<AddUserController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        public SuccessMessage Get(string name, string email, string phone, string login, string password)
        {
            var user = new UserModel
            {
                FullName = name,
                Email = email,
                Phone = phone,
                Login = login,
                Password = password,
            };
            var userAddService = new AddUser();
            var result = userAddService.TryExecute(user);
            return result;
        }
    }
}