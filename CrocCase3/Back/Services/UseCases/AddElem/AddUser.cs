namespace Services.UseCases.AddElem
{
    using DataModel;
    using DataModel.Models.User;

    /// <summary>
    /// Добавляет пользователя в базу данных в соответствующую таблицу (Users).
    /// </summary>
    public class AddUser
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="user">Информация о пользователе.</param>
        /// <returns>Идентификатор добавленного элемента.</returns>
        public int TryExecute(UserModel user)
        {
            if (string.IsNullOrEmpty(user.FullName))
                throw new UseCaseException("Имя пользователя не может быть пустым.");
            
            if (string.IsNullOrEmpty(user.Login))
                throw new UseCaseException("Логин пользователя не может быть пустым.");
            
            if (string.IsNullOrEmpty(user.Password))
                throw new UseCaseException("Пароль пользователя не может быть пустым.");

            if (string.IsNullOrEmpty(user.Email) && string.IsNullOrEmpty(user.Phone))
                throw new UseCaseException("Необходимо указать хотя бы один вид информации для связи.");
            
            if (string.IsNullOrEmpty(user.Color))
                throw new UseCaseException("Необходимо указать цвет пользователя.");

            using (var db = new DataContext())
            {
                var addedElem = db.Users.Add(user);
                db.SaveChanges();
                return addedElem.Entity.Id;
            }
        }
    }
}