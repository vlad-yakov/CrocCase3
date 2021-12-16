namespace Api.Models
{
    /// <summary>
    /// Описывает пользователя для возврата.
    /// </summary>
    public class UserReturnModel
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Полное имя пользователя.
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// Почта пользователя.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Телефон пользователя.
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Цвет пользователя.
        /// </summary>
        public string Color { get; set; }
    }
}