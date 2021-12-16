using System.Linq;
using DataModel;
using DataModel.Models.Duty;
using DataModel.Models.Project;
using Microsoft.EntityFrameworkCore;
using Services.UseCases.AuthorizeAndCheckPermissions;

namespace Services.UseCases.EditElem
{
    /// <summary>
    /// Редактирует проект в базе данных.
    /// </summary>
    public class EditProject
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="dutyInput">Информация о смене.</param>
        /// <param name="login">Логин пользователя.</param>
        /// <returns>Идентификатор добавленного элемента.</returns>
        public void TryExecute(ProjectModel project, string login)
        {
            if (string.IsNullOrEmpty(project.Name))
                throw new UseCaseException("Название проекта не может быть пустым.");

            var sysAdmin = new CheckSystemAdminByLogin().TryExecute(login);
            var projectAdmin = new CheckCurrentProjectAdminByLogin().TryExecute(login, project.Id);
            
            if (!(sysAdmin || projectAdmin))
                throw new UseCaseException("Недостаточно прав.");

            using (var db = new DataContext())
            {
                var updateElem =  db.Projects.Update(project);
                db.SaveChanges();
            }
        }
    }
}