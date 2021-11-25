using System;
using DataModel.Models;
using DataModel.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models;
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
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>Ответ сервера с информацией о результативности выполнения задания.</returns>
        [HttpGet]
        public SuccessMessage Get(string name, string email, string phone, string login, string password)
        {
            var user = new UserModel
            {
                FullName = name,
                Email = email,
                Phone = phone,
                Login = login,
                Password = password,
            };
            
            var result = new SuccessMessage();
            try
            {
                var userAddService = new AddUser();
                result = userAddService.TryExecute(user);

            }
            catch (Exception e)
            {
                result.Success = false;
                result.Reason.Add(e.Message);
            }
            
            return result;
        }
    }
}