using System;
using System.Collections.Generic;
using System.Linq;
using DataModel.Models;
using DataModel.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models;
using Services.UseCases.AddElem;
using Services.UseCases.GetElem;

namespace Api.Controllers.AddElems
{
    /// <summary>
    /// Контроллер, возвращающий все пользователей по совпадению передаваемой строки с полным именем.
    /// </summary>
    [ApiController]
    [Route("AddUser")]
    public class GetAllUsersByPartNameController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="partFullName">Часть имени пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public (SuccessMessage, List<UserModel>) Get(string partFullName)
        {
            var resultSuccess = new SuccessMessage();
            List<UserModel> resultUser = new(); 
            try
            {
                var usersGetByPartNameService = new GetAllUsersByPartFullName();
                resultUser = usersGetByPartNameService.TryExecute(partFullName).ToList();
            }
            catch (Exception e)
            {
                resultSuccess.Success = false;
                resultSuccess.Reason.Add(e.Message);
            }
            
            return (resultSuccess,resultUser);
        }
    }
}