using System.Collections.Generic;
using System.Linq;
using DataModel;
using DataModel.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Services.UseCases.GetElem
{
    /// <summary>
    /// Возвращает список всех пользователей состоящих в проекте с данным идентификатором.
    /// </summary>
    public class GetAllUsersByProjectId
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <returns>Результат выполнения действия.</returns>
        public IEnumerable<UserModel> TryExecute(int projectId)
        {
            List<UserModel> result = new();
            using (var db = new DataContext())
            {
                var users = db.Linker
                    .Where(linker => linker.ProjectId == projectId)
                    .Include(c => c.User)
                    .Select(x => x.User);

                result.AddRange(users);
            }
            
            return result;
        }
    }
}