using System.Collections.Generic;
using System.Linq;
using DataModel;
using DataModel.Models.User;

namespace Services.UseCases.GetElem
{
    /// <summary>
    /// Возвращает список всех пользователей по совпадению стрки с полным именем (поиск подстроки в строке).
    /// </summary>
    public class GetAllUsersByPartFullName
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="partFullName">Часть полниго имени для поиска.</param>
        /// <returns>Результат выполнения действия.</returns>
        public IEnumerable<UserModel> TryExecute(string partFullName)
        {
            List<UserModel> result = new();
            using (var db = new DataContext())
            {
                var userElems = db.Users
                    .Where(user => user.FullName.ToLower().Contains(partFullName.ToLower()) && !user.Deleted);
                
                result.AddRange(userElems);
            }
            
            return result;
        }
    }
}