using System.Linq;
using DataModel;
using Services.UseCases.AuthorizeAndCheckPermissions;

namespace Services.UseCases.RemoveElem
{
    /// <summary>
    /// Удаляет(скрывает) пользователя в проекте.
    /// </summary>
    public class RemoveLinkerById
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <param name="login">Логин пользователя</param>
        /// <exception cref="UseCaseException"></exception>
        public void TryExecute(int linkerId, string login)
        {
            int projectId;
            using (var db = new DataContext())
            {
                projectId = db.Linker.FirstOrDefault(linker => linker.Id == linkerId).ProjectId;
            }
            
            var sysAdmin = new CheckSystemAdminByLogin().TryExecute(login);
            var projectAdmin = new CheckCurrentProjectAdminByLogin().TryExecute(login, projectId);
            
            if (!(sysAdmin || projectAdmin))
                throw new UseCaseException("Недостаточно прав.");

            using (var db = new DataContext())
            {
                var linker = db.Linker.Find(linkerId);

                if (linker == null)
                    throw new UseCaseException("Не удалось найти элемент по заданному идентификатору.");

                linker.Deleted = true;
                db.Update(linker);
                db.SaveChanges();
            }
        }
    }
}