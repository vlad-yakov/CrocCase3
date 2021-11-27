namespace Api.Models
{
    /// <summary>
    /// Модель вывода запроса для API. 
    /// </summary>
    /// <typeparam name="T">Информация, необходимая для запроса.</typeparam>
    public class ResultMessage<T>
    {
        /// <summary>
        /// Успешность выполненого запроса.
        /// </summary>
        public SuccessMessage Success { get; set; }
        
        /// <summary>
        /// Выводимая информация.
        /// </summary>
        public T Result { get; set; }
    }
}