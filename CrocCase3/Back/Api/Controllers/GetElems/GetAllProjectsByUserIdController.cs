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
    /// Контроллер, возвращающий все проекты в которых состоит пользователь с данным идентификатором (Linker).
    /// </summary>
    [ApiController]
    [Route("GetAllProjectsByUserId")]
    public class GetAllProjectsByUserIdController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public ResultMessage<List<ProjectReturnModel>> Get(int userId)
        {
            ResultMessage<List<ProjectReturnModel>> result = new(); 
            try
            {
                var projectsGetByUserIdService = new GetAllProjectsByUserId();
                result.Result = projectsGetByUserIdService
                    .TryExecute(userId)
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