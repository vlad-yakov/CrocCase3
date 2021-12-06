using System.Linq;
using DataModel;
using DataModel.Models.Duty;
using Microsoft.EntityFrameworkCore;
using Services.UseCases.AuthorizeAndCheckPermissions;

namespace Services.UseCases.EditElem
{
    /// <summary>
    /// Редактирует смену в базе данных.
    /// </summary>
    public class EditDuty
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="dutyInput">Информация о смене.</param>
        /// <param name="login">Логин пользователя.</param>
        /// <returns>Идентификатор добавленного элемента.</returns>
        public void TryExecute(DutyModel dutyInput, string login)
        {
            if (dutyInput.Start == null)
                throw new UseCaseException("Дата начала смены не может быть пустой.");
            
            if (dutyInput.Finish == null)
                throw new UseCaseException("Дата конца смены не может быть пустой.");
            
            if (dutyInput.LinkerId <= 0)
                throw new UseCaseException("Идентификатор линкера не может быть пустым.");

            int projectId;
            using (var db = new DataContext())
            {
                projectId = db.Linker.FirstOrDefault(linker => linker.Id == dutyInput.LinkerId).ProjectId;
            }
            
            string userLogin;
            using (var db = new DataContext())
            {
                var userLoginObj = db.Linker
                    .Where(linker => linker.Id == dutyInput.LinkerId)
                    .Include(linker => linker.User)
                    .FirstOrDefault();

                if (userLoginObj == null)
                    throw new UseCaseException("Недостаточно прав.");

                userLogin = userLoginObj.User.Login;
            }
            
            var sysAdmin = new CheckSystemAdminByLogin().TryExecute(login);
            var projectAdmin = new CheckCurrentProjectAdminByLogin().TryExecute(login, projectId);
            
            if (!(sysAdmin || projectAdmin) || userLogin != login)
                throw new UseCaseException("Недостаточно прав.");
            
            using (var db = new DataContext())
            {
                var addedElem = db.Duties.Update(dutyInput);
                db.SaveChanges();
            }
        }
    }
}