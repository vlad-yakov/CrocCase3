namespace Services.UseCases.AddElem
{
    using DataModel;
    using DataModel.Models.User;

    using Models;

    /// <summary>
    /// Добавляет пользователя в базу данных в соответствующую таблицу (Users).
    /// </summary>
    public class AddUser
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="user">Информация о пользователе.</param>
        /// <returns>Результат выполнения действия.</returns>
        public SuccessMessage TryExecute(UserModel user)
        {
            if (string.IsNullOrEmpty(user.FullName))
                throw new UseCaseException("Имя пользователя не может быть пустым.");
            
            if (string.IsNullOrEmpty(user.Login))
                throw new UseCaseException("Логин пользователя не может быть пустым.");
            
            if (string.IsNullOrEmpty(user.Password))
                throw new UseCaseException("Пароль пользователя не может быть пустым.");

            if (string.IsNullOrEmpty(user.Email) && string.IsNullOrEmpty(user.Phone))
                throw new UseCaseException("Необходимо указать хотя бы один вид информации для связи.");


            using (var db = new DataContext())
            {
                db.Users.Add(user);
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