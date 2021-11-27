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
            using (DataContext db = new DataContext())
            {
                var userElems = db.Users
                    .Where(e => e.FullName.ToLower().Contains(partFullName.ToLower()))
                    .Select(e => new UserModel
                    {
                        Id = e.Id,
                        FullName = e.FullName,
                        Email = e.Email,
                        Phone = e.Phone
                    });
                
                result.AddRange(userElems);
            }
            
            return result;
        }
    }
}