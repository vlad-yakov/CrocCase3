using System;
using Api.Controllers.Authorize;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Services.UseCases.RemoveElem;

namespace Api.Controllers.DeleteElems
{
    /// <summary>
    /// Контроллер, удаляющий смену.
    /// </summary>
    [ApiController]
    [Route("RemoveDutyById")]
    public class RemoveDutyByIdController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="dutyId">Идентификатор смены, которую нужно удалить.</param>
        /// <param name="token">Токен пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public SuccessMessage Get(int dutyId, string token)
        {
            var result = new SuccessMessage();
            
            var dutyRemoveService = new RemoveDutyById();
            try
            {
                var userLogin = new TokenOperations().CheckToken(token);
                dutyRemoveService.TryExecute(dutyId, userLogin);
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