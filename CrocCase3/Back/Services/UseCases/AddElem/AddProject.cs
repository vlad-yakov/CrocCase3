using DataModel.Models.Project;
using DataModel.Models.Project;
using Services.UseCases.AuthorizeAndCheckPermissions;

namespace Services.UseCases.AddElem
{
    using DataModel;

    /// <summary>
    /// Добавляет информацию о проекте в базу данных в соответствующую таблицу (Projects).
    /// </summary>
    public class AddProject
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="project">Информация о проекте.</param>
        /// <param name="userLogin">Логин пользователя.</param>
        /// <returns>Идентификатор добавленного элемента.</returns>
        public int TryExecute(ProjectModel project, string userLogin)
        {
            if (string.IsNullOrEmpty(project.Name))
                throw new UseCaseException("Название проекта не может быть пустым.");

            if (!new CheckSystemAdminByLogin().TryExecute(userLogin))
                throw new UseCaseException("Недостаточно прав на выполнение данного действия.");

            using (var db = new DataContext())
            {
                var addedElem =  db.Projects.Add(project);
                db.SaveChanges();
                return addedElem.Entity.Id;
            }
        }
    }
}