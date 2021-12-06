using System;
using Api.Controllers.Authorize;
using Api.Models;
using DataModel.Models.Duty;
using Microsoft.AspNetCore.Mvc;
using Services.UseCases.AddElem;
using Services.UseCases.EditElem;

namespace Api.Controllers.AddElems
{
    /// <summary>
    /// Контроллер, изменяющий смену для пользователя в таблице.
    /// </summary>
    [ApiController]
    [Route("EditDuty")]
    public class EditDutyController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="id">Идентификатор смены.</param>
        /// <param name="start">Имя пользователя.</param>
        /// <param name="end">Почта для связи с данным пользователем.</param>
        /// <param name="linkerId">Телефон для связи с данным пользователем.</param>
        /// <param name="token">Токен пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public SuccessMessage Get(int id, DateTime start, DateTime end, int linkerId, string token)
        {
            var duty = new DutyModel
            {
                Id = id,
                Start = start,
                Finish = end,
                LinkerId = linkerId
            };
            
            var result = new SuccessMessage();
            try
            {
                var userLogin = new TokenOperations().CheckToken(token);
                var dutyAddService = new EditDuty();
                dutyAddService.TryExecute(duty, userLogin);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Reason.Add(e.Message);
                return result;
            }

            return result;
        }
    }
}