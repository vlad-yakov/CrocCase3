using System;
using System.Collections.Generic;
using System.Linq;
using DataModel;
using DataModel.Models.Duty;
using DataModel.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Services.UseCases.GetElem
{
    /// <summary>
    /// Контроллер, возвращающий все смены в проекте по данному идентификатору на заданном промежутке (Linker).
    /// </summary>
    public class GetAllDutiesByProjectId
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <param name="start">Начало необходимого промежутка.</param>
        /// <param name="finish">Конец необходимого промежутка.</param>
        /// <returns>Результат выполнения действия.</returns>
        public IEnumerable<DutyModel> TryExecute(int projectId, DateTime start, DateTime finish)
        {
            List<DutyModel> result = new();
            using (var db = new DataContext())
            {
                var users = db.Linker
                    .Where(linker => linker.ProjectId == projectId)
                    .Include(c => c.Duty)
                    .Select(x => x.Duty)
                    .FirstOrDefault()
                    ?.Where(duty => duty.Start >= start && duty.Start <= finish);

                if (users == null)
                    throw new UseCaseException("Не найденно задач в данном временном промежутке.");

                result.AddRange(users);
            }
            
            return result;
        }
    }
}