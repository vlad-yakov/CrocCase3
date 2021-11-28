using System.Linq;
using DataModel;
using DataModel.Models.Project;
using DataModel.Models.User;

namespace Services.UseCases.GetElem
{
    /// <summary>
    /// Возвращает проект с переданным идектификатором.
    /// </summary>
    public class GetProjectById
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <returns>Результат выполнения действия.</returns>
        public ProjectModel TryExecute(int projectId)
        {
            if (projectId < 0)
                throw new UseCaseException("Идентификатор не может быть меньше.");
            
            var result = new ProjectModel();
            using (var db = new DataContext())
            {
                var projectElem = db.Projects
                    .Where(e => e.Id == projectId)
                    .ToList()
                    .FirstOrDefault();

                if (projectElem == null)
                    throw new UseCaseException("Не удалось найти пользователя по данному идентификатору.");
                
                result = projectElem;
            }
            
            return result;
        }
    }
}