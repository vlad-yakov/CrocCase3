using System.Linq;
using DataModel;

namespace Services.UseCases.AuthorizeAndCheckPermissions
{
    /// <summary>
    /// Контроллер, возвращающий, булево значение, показывающее является ли пользователь с данным логином администратором приложения.
    /// </summary>
    public class CheckSystemAdminByLogin
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <returns>Результат выполнения действия.</returns>
        public bool TryExecute(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new UseCaseException("Укажите логин.");
            
            using (var db = new DataContext())
            {
                var users = db.Users.FirstOrDefault(x => x.Login == login && x.SystemAdmin);

                if (users == null)
                    return false;
            }
            
            return true;
        }
    }
}