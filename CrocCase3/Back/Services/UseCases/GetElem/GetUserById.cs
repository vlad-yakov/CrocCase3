using System.Linq;
using DataModel;
using DataModel.Models.User;

namespace Services.UseCases.GetElem
{
    /// <summary>
    /// Возвращает пользователя с данным идентификатором.
    /// </summary>
    public class GetUserById
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Результат выполнения действия.</returns>
        public UserModel TryExecute(int userId)
        {
            if (userId < 0)
                throw new UseCaseException("Идентификатор не может быть меньше.");
            
            var result = new UserModel();
            using (var db = new DataContext())
            {
                var userElem = db.Users
                    .Where(user => user.Id == userId && !user.Deleted)
                    .Select(e => new UserModel
                    {
                        Id = e.Id,
                        FullName = e.FullName,
                        Email = e.Email,
                        Phone = e.Phone
                    })
                    .ToList()
                    .FirstOrDefault();

                if (userElem == null)
                    throw new UseCaseException("Не удалось найти пользователя по данному идентификатору.");
                
                result = userElem;
            }
            
            return result;
        }
    }
}