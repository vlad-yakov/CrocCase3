using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using DataModel.Models.User;
using Microsoft.AspNetCore.Mvc;
using Services.UseCases.GetElem;

namespace Api.Controllers.GetElems
{
    /// <summary>
    /// Контроллер, возвращающий все смены в проекте по данному идентификатору на заданном промежутке (Linker).
    /// </summary>
    [ApiController]
    [Route("GetAllDutiesByProjectId")]
    public class GetAllDutiesByProjectIdController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <param name="start">Начало необходимого промежутка.</param>
        /// <param name="finish">Конец необходимого промежутка.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public ResultMessage<List<DutyReturnModel>> Get(int projectId, DateTime start, DateTime finish)
        {
            ResultMessage<List<DutyReturnModel>> result = new(); 
            try
            {
                var dutiesGetByProjectIdService = new GetAllDutiesByProjectId();
                result.Result = dutiesGetByProjectIdService
                    .TryExecute(projectId, start, finish)
                    .Select(duty => new DutyReturnModel
                    {
                        Id = duty.Id,
                        Start = duty.Start,
                        Finish = duty.Finish,
                        GroupId = duty.GroupId,
                        LinkerId = duty.LinkerId
                    })
                    .ToList();
                
                result.Success.Success = true;
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