using System;
using Api.Controllers.Authorize;
using Api.Models;
using DataModel.Models;
using DataModel.Models.Duty;
using DataModel.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.UseCases.AddElem;

namespace Api.Controllers.AddElems
{
    /// <summary>
    /// Контроллер, добавляющий смену для пользователя. в таблицу.
    /// </summary>
    [ApiController]
    [Route("AddDuty")]
    public class AddDutyController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="start">Имя пользователя.</param>
        /// <param name="end">Почта для связи с данным пользователем.</param>
        /// <param name="linkerId">Телефон для связи с данным пользователем.</param>
        /// <param name="token">Токен пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public ResultMessage<int> Get(DateTime start, DateTime end, int linkerId, string token)
        {
            var duty = new DutyModel
            {
                Start = start,
                Finish = end,
                LinkerId = linkerId
            };
            
            var result = new ResultMessage<int>();
            try
            {
                var userLogin = new TokenOperations().CheckToken(token);
                var dutyAddService = new AddDuty();
                result.Result = dutyAddService.TryExecute(duty, userLogin);
                result.Success.Success = true;
            }
            catch (Exception e)
            {
                result.Success.Success = false;
                result.Success.Reason.Add(e.Message);
                return result;
            }

            return result;
        }
    }
}