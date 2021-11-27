using DataModel.Models.Project;
using DataModel.Models.Project;

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
        /// <returns>Идентификатор добавленного элемента.</returns>
        public int TryExecute(ProjectModel project)
        {
            if (string.IsNullOrEmpty(project.Name))
                throw new UseCaseException("Название проекта не может быть пустым.");

            using (var db = new DataContext())
            {
                var addedElem =  db.Projects.Add(project);
                db.SaveChanges();
                return addedElem.Entity.Id;
            }
        }
    }
}