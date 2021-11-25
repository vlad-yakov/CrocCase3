using System;
using DataModel.Models;
using DataModel.Models.Duty;
using DataModel.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models;
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
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public SuccessMessage Get(DateTime start, DateTime end, int linkerId)
        {
            var duty = new DutyModel
            {
                Start = start,
                Finish = end,
                LinkerId = linkerId
            };
            
            var result = new SuccessMessage();
            try
            {
                var dutyAddService = new AddDuty();
                result = dutyAddService.TryExecute(duty);

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