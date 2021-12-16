using System;
using Api.Controllers.Authorize;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Services.UseCases.RemoveElem;

namespace Api.Controllers.DeleteElems
{
    /// <summary>
    /// Контроллер, удаляющий проект.
    /// </summary>
    [ApiController]
    [Route("RemoveProject")]
    public class RemoveProjectController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="projectId">Идентификатор проекта, который нужно удалить.</param>
        /// <param name="token">Токен пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public SuccessMessage Get(int projectId, string token)
        {
            var result = new SuccessMessage();
            
            var projectRemoveService = new RemoveProject();
            try
            {
                var userLogin = new TokenOperations().CheckToken(token);
                projectRemoveService.TryExecute(projectId, userLogin);
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