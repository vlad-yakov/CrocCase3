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
    /// Контроллер, возвращающий всех пользователей состоящих в проэкте с данным идентификатором (Linker).
    /// </summary>
    [ApiController]
    [Route("GetAllUsersByProjectId")]
    public class GetAllUsersByProjectIdController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public ResultMessage<List<UserReturnModel>> Get(int projectId)
        {
            ResultMessage<List<UserReturnModel>> result = new(); 
            try
            {
                var usersGetByProjectIdService = new GetAllUsersByProjectId();
                result.Result = usersGetByProjectIdService
                    .TryExecute(projectId)
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