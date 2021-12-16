using System;
using Api.Controllers.Authorize;
using Api.Models;
using DataModel.Models;
using DataModel.Models.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.UseCases.AddElem;
using Services.UseCases.EditElem;

namespace Api.Controllers.AddElems
{
    /// <summary>
    /// Контроллер, изменяющий проект в таблице.
    /// </summary>
    [ApiController]
    [Route("EditProject")]
    public class EditProjectController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="id">Идентификатор проекта.</param>
        /// <param name="name">Название проекта.</param>
        /// <param name="beginDate">Дата начала проекта.</param>
        /// <param name="endDate">Дата окончания проекта.</param>
        /// <param name="daysPerWeek">Рабочих дней в неделе.</param>
        /// <param name="token">Токен пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public SuccessMessage Get(int id, string name, DateTime beginDate, DateTime endDate, int daysPerWeek, string token)
        {
            var project = new ProjectModel
            {
                Id = id,
                Name = name,
                BeginDate = beginDate,
                EndDate = endDate,
                DaysPerWeek = daysPerWeek
            };

            var result = new SuccessMessage();
            try
            {
                var userLogin = new TokenOperations().CheckToken(token);
                var projectAddService = new EditProject();
                projectAddService.TryExecute(project, userLogin);
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