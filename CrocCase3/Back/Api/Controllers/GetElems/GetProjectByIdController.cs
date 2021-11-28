using System;
using System.Collections.Generic;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Services.UseCases.GetElem;

namespace Api.Controllers.GetElems
{
    /// <summary>
    /// Контроллер, возвращающий проект с данным идентификатором.
    /// </summary>
    [ApiController]
    [Route("GetProjectById")]
    public class GetProjectByIdController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public ResultMessage<ProjectReturnModel> Get(int projectId)
        {
            ResultMessage<ProjectReturnModel> result = new(); 
            try
            { 
                var projectGetByIdService = new GetProjectById(); 
                var project = projectGetByIdService.TryExecute(projectId);
                result.Result = new ProjectReturnModel
                {
                    Id = project.Id,
                    Name = project.Name,
                    BeginDate = project.BeginDate,
                    EndDate = project.EndDate,
                    DaysPerWeek = project.DaysPerWeek
                };
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