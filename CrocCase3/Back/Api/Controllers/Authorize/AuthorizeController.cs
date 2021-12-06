using System;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Services.UseCases.Authorize;

namespace Api.Controllers.Authorize
{
    /// <summary>
    /// Контроллер, возвращающий все смены в проекте по данному идентификатору на заданном промежутке (Linker).
    /// </summary>
    [ApiController]
    [Route("Authorize")]
    public class AuthorizeController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <param name="start">Начало необходимого промежутка.</param>
        /// <param name="finish">Конец необходимого промежутка.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public ResultMessage<string> Get(string login, string password)
        {
            ResultMessage<string> result = new(); 
            try
            {
                var chechProfileService = new CheckProfile();
                var checkProfile = chechProfileService
                    .TryExecute(login, password);
                if (!checkProfile)
                {
                    throw new Exception("Данного пользователя нет.");
                }
                
                result.Success.Success = true;
                result.Result = new TokenOperations().CreateToken(login) ;
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