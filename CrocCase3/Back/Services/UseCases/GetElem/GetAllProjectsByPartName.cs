using System.Collections.Generic;
using System.Linq;
using DataModel;
using DataModel.Models.Project;
using DataModel.Models.User;

namespace Services.UseCases.GetElem
{
    /// <summary>
    /// Возвращает список всех проектов по совпадению стрки с полным именем (поиск подстроки в строке).
    /// </summary>
    public class GetAllProjectsByPartName
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="partName">Часть полниго имени для поиска.</param>
        /// <returns>Результат выполнения действия.</returns>
        public IEnumerable<ProjectModel> TryExecute(string partName)
        {
            List<ProjectModel> result = new();
            using (var db = new DataContext())
            {
                var projectElems = db.Projects
                    .Where(e => e.Name.ToLower().Contains(partName.ToLower()));
                
                result.AddRange(projectElems);
            }
            
            return result;
        }
    }
}