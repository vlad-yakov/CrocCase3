using System;
using Api.Models;
using DataModel.Models;
using DataModel.Models.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.UseCases.AddElem;

namespace Api.Controllers.AddElems
{
    /// <summary>
    /// Контроллер, добавляющий проект в таблицу.
    /// </summary>
    [ApiController]
    [Route("AddProject")]
    public class AddProjectController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="name">Название проекта.</param>
        /// <param name="beginDate">Дата начала проекта.</param>
        /// <param name="endDate">Дата окончания проекта.</param>
        /// <param name="daysPerWeek">Рабочих дней в неделе.</param>
        /// <param name="token">Токен пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public ResultMessage<int> Get(string name, DateTime beginDate, DateTime endDate, int daysPerWeek, string token)
        {
            var project = new ProjectModel
            {
                Name = name,
                BeginDate = beginDate,
                EndDate = endDate,
                DaysPerWeek = daysPerWeek
            };

            var result = new ResultMessage<int>();
            try
            {
                var projectAddService = new AddProject();
                result.Result = projectAddService.TryExecute(project);
            }
            catch (Exception e)
            {
                result.Success.Success = false;
                result.Success.Reason.Add(e.Message);
            }

            result.Success.Success = true;
            return result;
        }
    }
}