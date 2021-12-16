using System;
using Api.Controllers.Authorize;
using Api.Models;
using DataModel.Models;
using DataModel.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.UseCases.AddElem;

namespace Api.Controllers.AddElems
{
    /// <summary>
    /// Контроллер, добавляющий пользователя в таблицу.
    /// </summary>
    [ApiController]
    [Route("AddUser")]
    public class AddUserController : ControllerBase
    {
        /// <summary>
        /// Получить ответ от сервера.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <param name="email">Почта для связи с данным пользователем.</param>
        /// <param name="phone">Телефон для связи с данным пользователем.</param>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="color">Цвет пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <param name="token">Токен пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public ResultMessage<int> Get(string name, string email, string phone, string color, string login, string password, string token, bool sysAdmin)
        {
            var user = new UserModel
            {
                FullName = name,
                Email = email,
                Phone = phone,
                Color = color,
                Login = login,
                Password = password,
                SystemAdmin = sysAdmin
            };
            
            var result = new ResultMessage<int>();
            try
            {
                // var userLogin = new TokenOperations().CheckToken(token);
                var userAddService = new AddUser();
                result.Result = userAddService.TryExecute(user, String.Empty);
                result.Success.Success = true;
            }
            catch (Exception e)
            {
                result.Success.Success = false;
                result.Success.Reason.Add(e.Message);
            }

            return result;
        }
    }
}