using System;
using System.Collections.Generic;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Services.UseCases.GetElem;

namespace Api.Controllers.GetElems
{
    /// <summary>
    /// Контроллер, возвращающий пользователя с данным идентификатором..
    /// </summary>
    [ApiController]
    [Route("GetUserById")]
    public class GetUserByIdController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public ResultMessage<UserReturnModel> Get(int userId)
        {
            ResultMessage<UserReturnModel> result = new(); 
            try
            {
                var usersGetByIdService = new GetUserById();
               var user = usersGetByIdService.TryExecute(userId);
                result.Result = new UserReturnModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    Phone = user.Phone,
                    Color = user.Color
                };
                
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