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
    /// Контроллер, возвращающий всех пользователей.
    /// </summary>
    [ApiController]
    [Route("GetAllUsers")]
    public class GetAllUsersController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public ResultMessage<List<UserReturnModel>> Get()
        {
            ResultMessage<List<UserReturnModel>> result = new(); 
            try
            {
                var usersGetService = new GetAllUsers();
                result.Result = usersGetService
                    .TryExecute()
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