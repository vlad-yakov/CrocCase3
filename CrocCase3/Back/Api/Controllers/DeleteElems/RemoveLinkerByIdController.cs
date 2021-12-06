using System;
using Api.Controllers.Authorize;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Services.UseCases.RemoveElem;

namespace Api.Controllers.DeleteElems
{
    /// <summary>
    /// Контроллер, удаляющий связующую запись в линкере.
    /// </summary>
    [ApiController]
    [Route("RemoveLinkerById")]
    public class RemoveLinkerByIdController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="linkerId">Идентификатор смены, которую нужно удалить.</param>
        /// <param name="token">Токен пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public SuccessMessage Get(int linkerId, string token)
        {
            var result = new SuccessMessage();
            
            var linkerRemoveService = new RemoveLinkerById();
            try
            {
                var userLogin = new TokenOperations().CheckToken(token);
                linkerRemoveService.TryExecute(linkerId, userLogin);
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