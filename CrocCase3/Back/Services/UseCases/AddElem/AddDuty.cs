using System.Linq;
using DataModel.Models.Duty;
using DataModel.Models.Project;
using Microsoft.EntityFrameworkCore;
using Services.UseCases.AuthorizeAndCheckPermissions;

namespace Services.UseCases.AddElem
{
    using DataModel;

    /// <summary>
    /// Добавляет смену в базу данных в соответствующую таблицу (Duties).
    /// </summary>
    public class AddDuty
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="dutyInput">Информация о смене.</param>
        /// <param name="login">Логин пользователя.</param>
        /// <returns>Идентификатор добавленного элемента.</returns>
        public int TryExecute(DutyModel dutyInput, string login)
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
                var addedElem = db.Duties.Add(dutyInput);
                db.SaveChanges();
                return addedElem.Entity.Id;
            }
        }
    }
}