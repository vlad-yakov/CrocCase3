using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using DataModel.Models.User;
using Microsoft.AspNetCore.Mvc;
using Services.UseCases.GetElem;

namespace Api.Controllers.GetElems
{
    /// <summary>
    /// Контроллер, возвращающий всех пользователей по совпадению передаваемой строки с полным именем.
    /// </summary>
    [ApiController]
    [Route("GetAllUsersByPartName")]
    public class GetAllUsersByPartNameController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="partFullName">Часть имени пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public ResultMessage<List<UserReturnModel>> Get(string partFullName)
        {
            ResultMessage<List<UserReturnModel>> result = new(); 
            try
            {
                var usersGetByPartNameService = new GetAllUsersByPartFullName();
                result.Result = usersGetByPartNameService
                    .TryExecute(partFullName)
                    .Select(user => new UserReturnModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FullName = user.FullName,
                        Phone = user.Phone,
                        Color = user.Color
                    })
                    .ToList();
                
                result.Success.Success = true;
            }
            catch (Exception e)
            {
                result.Success.Success = false;
                result.Success.Reason.Add(e.Message);
            }

            return result;
        }
    }
}