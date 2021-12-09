using System.Collections.Generic;
using System.Linq;
using DataModel;
using DataModel.Models.User;

namespace Services.UseCases.GetElem
{
    /// <summary>
    /// Возвращает список всех пользователей.
    /// </summary>
    public class GetAllUsers
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <returns>Результат выполнения действия.</returns>
        public IEnumerable<UserModel> TryExecute()
        {
            List<UserModel> result = new();
            using (var db = new DataContext())
            {
                var userElems = db.Users
                    .Where(user => !user.Deleted);
                
                result.AddRange(userElems);
            }
            
            return result;
        }
    }
}