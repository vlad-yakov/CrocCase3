using DataModel.Models.Linker;

namespace Services.UseCases.AddElem
{
    using DataModel;
    using DataModel.Models.User;

    /// <summary>
    /// Добавляет пользователя в проект (linker).
    /// </summary>
    public class AddUserInProject
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="linker">Информация о связи пользователя и проекта.</param>
        public void TryExecute(LinkerUserProject linker)
        {
            if (linker.ProjectId <= 0)
                throw new UseCaseException("Идентификатор проекта не может быть меньше или равен нулю.");

            if (linker.UserId <= 0)
                throw new UseCaseException("Идентификатор пользователя не может быть меньше или равен нулю.");
            
            if (linker.RoleType != 1 && linker.RoleType !=99)
                throw new UseCaseException("Необходимо указать роль пользователя.");

            
            using (var db = new DataContext())
            {
                db.Linker.Add(linker);
                db.SaveChanges();
            }
        }
    }
}