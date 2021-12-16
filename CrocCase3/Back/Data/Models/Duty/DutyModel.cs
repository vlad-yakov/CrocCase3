using System;
using DataModel.Models.Linker;

namespace DataModel.Models.Duty
{
    /// <summary>
    /// Описывает смену.
    /// </summary>
    public class DutyModel
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
        
        /// <summary>
        /// Показывает удалили ли элемент.
        /// </summary>
        public bool Deleted { get; set; }
        
        /// <summary>
        /// Связанный линкер.
        /// </summary>
        public LinkerUserProject Linker { get; set; }
    }
}