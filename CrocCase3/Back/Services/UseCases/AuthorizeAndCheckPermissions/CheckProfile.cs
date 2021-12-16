using System.Linq;
using DataModel;

namespace Services.UseCases.Authorize
{
    /// <summary>
    /// Контроллер, возвращающий, булево значение, показывающее прошла автользация или нет.
    /// </summary>
    public class CheckProfile
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>Результат выполнения действия.</returns>
        public bool TryExecute(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
                throw new UseCaseException("Укажите логин.");
            
            if (string.IsNullOrEmpty(password))
                throw new UseCaseException("Укажите пароль.");
            
            using (var db = new DataContext())
            {
                var users = db.Users.FirstOrDefault(x => x.Login == login && x.Password == password);

                if (users == null)
                    return false;
            }
            
            return true;
        }
    }
}