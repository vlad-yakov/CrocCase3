using System.Linq;
using DataModel;
using DataModel.Models.Linker;
using Microsoft.EntityFrameworkCore;
using Services.UseCases.AuthorizeAndCheckPermissions;

namespace Services.UseCases.RemoveElem
{
    /// <summary>
    /// Удаляет(скрывает) смену.
    /// </summary>
    public class RemoveDutyById
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="projectId">Идентификатор проекта.</param>
        /// <param name="login">Логин пользователя</param>
        /// <exception cref="UseCaseException"></exception>
        public void TryExecute(int dutyId, string login)
        {
            int projectId;
            using (var db = new DataContext())
            {
                projectId = db.Duties
                    .Where(duty => duty.Id == dutyId)
                    .Include(duty => duty.Linker)
                    .FirstOrDefault()
                    .Linker.ProjectId;
            }

            string userLogin;
            using (var db = new DataContext())
            {
                userLogin = db.Duties
                    .Where(duty => duty.Id == dutyId)
                    .Include(duty => duty.Linker)
                    .Include(linker => linker.Linker.User)
                    .FirstOrDefault()
                    .Linker.User.Login;
            }
            
            var sysAdmin = new CheckSystemAdminByLogin().TryExecute(login);
            var projectAdmin = new CheckCurrentProjectAdminByLogin().TryExecute(login, projectId);
            
            if (!(sysAdmin || projectAdmin) || userLogin != login)
                throw new UseCaseException("Недостаточно прав.");

            using (var db = new DataContext())
            {
                var duty = db.Duties.Find(dutyId);

                if (duty == null)
                    throw new UseCaseException("Не удалось найти элемент по заданному идентификатору.");

                duty.Deleted = true;
                db.Update(duty);
                db.SaveChanges();
            }
        }
    }
}