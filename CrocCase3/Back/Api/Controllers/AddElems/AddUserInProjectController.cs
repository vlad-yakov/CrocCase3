using System;
using Api.Controllers.Authorize;
using Api.Models;
using DataModel.Models;
using DataModel.Models.Linker;
using DataModel.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.UseCases.AddElem;

namespace Api.Controllers.AddElems
{
    /// <summary>
    /// Контроллер, добавляющий пользователя в таблицу.
    /// </summary>
    [ApiController]
    [Route("AddUserInProject")]
    public class AddUserInProjectController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <param name="role">Роль пользователя.</param>
        /// <param name="token">Токен пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public SuccessMessage Get(int userId, int projectId, int role, string token)
        {
            var linker = new LinkerUserProject
            {
                UserId = userId,
                ProjectId = projectId,
                RoleType = role
            };
            
            var result = new SuccessMessage();
            try
            {
                var userLogin = new TokenOperations().CheckToken(token);
                var userAddInProjectService = new AddUserInProject();
                userAddInProjectService.TryExecute(linker, userLogin);
                result.Success = true;

            }
            catch (Exception e)
            {
                result.Success = false;
                result.Reason.Add(e.Message);
            }

            return result;
        }
    }
}