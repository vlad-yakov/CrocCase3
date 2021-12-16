using System;

namespace Api.Models
{
    /// <summary>
    /// Описывает смену для возврата.
    /// </summary>
    public class DutyReturnModel
    {
        /// <summary>
        /// Идентификатор смены.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Идентификатор линкера, связывающего пользователя и проект.
        /// </summary>
        public int LinkerId { get; set; }
        
        /// <summary>
        /// Рекурсивный идентификатор.
        /// </summary>
        public int GroupId { get; set; }
        
        /// <summary>
        /// Начало смены.
        /// </summary>
        public DateTime Start { get; set; }
        
        /// <summary>
        /// Конец смены.
        /// </summary>
        public DateTime Finish { get; set; }
    }
}