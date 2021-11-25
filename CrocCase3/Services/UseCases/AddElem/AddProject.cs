using DataModel.Models.Project;

namespace Services.UseCases.AddElem
{
    using DataModel;
    using DataModel.Models.User;

    using Models;

    /// <summary>
    /// Добавляет информацию о проекте в базу данных в соответствующую таблицу (Projects).
    /// </summary>
    public class AddProject
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="project">Информация о проекте.</param>
        /// <returns>Результат выполнения действия.</returns>
        public SuccessMessage TryExecute(ProjectModel project)
        {
            if (string.IsNullOrEmpty(project.Name))
                throw new UseCaseException("Название проекта не может быть пустым.");

            using (var db = new DataContext())
            {
                db.Projects.Add(project);
                db.SaveChanges();
            }

            var result = new SuccessMessage
            {
                Success = true
            };
            
            return result;
        }
    }
}