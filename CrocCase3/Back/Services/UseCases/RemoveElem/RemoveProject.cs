using DataModel;
using Services.UseCases.AuthorizeAndCheckPermissions;

namespace Services.UseCases.RemoveElem
{
    /// <summary>
    /// Удаляет(скрывает) проект.
    /// </summary>
    public class RemoveProject
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <param name="login">Логин пользователя</param>
        /// <exception cref="UseCaseException"></exception>
        public void TryExecute(int projectId, string login)
        {
            var sysAdmin = new CheckSystemAdminByLogin().TryExecute(login);
            var projectAdmin = new CheckCurrentProjectAdminByLogin().TryExecute(login, projectId);
            
            if (!(sysAdmin || projectAdmin))
                throw new UseCaseException("Недостаточно прав.");

            using (var db = new DataContext())
            {
                var project = db.Projects.Find(projectId);

                if (project == null)
                    throw new UseCaseException("Не удалось найти элемент по заданному идентификатору.");

                project.Deleted = true;
                db.Update(project);
                db.SaveChanges();
            }
        }
    }
}