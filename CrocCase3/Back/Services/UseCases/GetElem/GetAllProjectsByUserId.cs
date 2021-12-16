using System.Collections.Generic;
using System.Linq;
using DataModel;
using DataModel.Models.Project;
using DataModel.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Services.UseCases.GetElem
{
    /// <summary>
    /// Возвращает список всех проектов, в которых состоит пользователь.
    /// </summary>
    public class GetAllProjectsByUserId
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Результат выполнения действия.</returns>
        public IEnumerable<ProjectModel> TryExecute(int userId)
        {
            List<ProjectModel> result = new();
            using (var db = new DataContext())
            {
                var projects = db.Linker
                    .Where(linker => linker.UserId == userId && !linker.Deleted)
                    .Include(c => c.Project)
                    .Select(x => x.Project);

                result.AddRange(projects);
            }
            
            return result;
        }
    }
}