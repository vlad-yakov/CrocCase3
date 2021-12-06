using System.Linq;
using DataModel;
using Microsoft.EntityFrameworkCore;

namespace Services.UseCases.AuthorizeAndCheckPermissions
{
    /// <summary>
    /// Контроллер, возвращающий, булево значение, показывающее является ли пользователь с данным логином администратором данного проекта.
    /// </summary>
    public class CheckCurrentProjectAdminByLogin
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <returns>Результат выполнения действия.</returns>
        public bool TryExecute(string login, int projectId)
        {
            if (string.IsNullOrEmpty(login))
                throw new UseCaseException("Укажите логин.");
            
            if (projectId < 1)
                throw new UseCaseException("Неверный идентификатор проекта.");

            using (var db = new DataContext())
            {
                var users = db.Users
                    .Where(u => u.Login == login)
                    .Include(u => u.Linker)
                    .FirstOrDefault(project =>
                        project.Linker.Any(linker => linker.ProjectId == projectId));
                
                if (users == null)
                    return false;
            }
            
            return true;
        }
    }
}