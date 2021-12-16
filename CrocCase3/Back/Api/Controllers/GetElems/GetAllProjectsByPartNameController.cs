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
    /// Контроллер, возвращающий все проекты по совпадению передаваемой строки с полным именем.
    /// </summary>
    [ApiController]
    [Route("GetAllProjectsByPartName")]
    public class GetAllProjectsByPartNameController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="partName">Часть названия проекта..</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public ResultMessage<List<ProjectReturnModel>> Get(string partName)
        {
            ResultMessage<List<ProjectReturnModel>> result = new(); 
            try
            {
                var projectsGetByPartNameService = new GetAllProjectsByPartName();
                result.Result = projectsGetByPartNameService
                    .TryExecute(partName)
                    .Select(project => new ProjectReturnModel()
                    {
                        Id = project.Id,
                        Name = project.Name,
                        BeginDate = project.BeginDate,
                        EndDate = project.EndDate,
                        DaysPerWeek = project.DaysPerWeek
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