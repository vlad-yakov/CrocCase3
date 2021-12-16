using System;

namespace Api.Models
{
    /// <summary>
    /// Описывает проект для возврата.
    /// </summary>
    public class ProjectReturnModel
    {
        /// <summary>
        /// Идентификатор проекта.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название проекта.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Дата начала проекта.
        /// </summary>
        public DateTime BeginDate { get; set; }
        
        /// <summary>
        /// Дата окончания проекта.
        /// </summary>
        public DateTime EndDate { get; set; }
        
        /// <summary>
        /// Количество рабочих дней в неделю в проекте. 
        /// </summary>
        public int DaysPerWeek { get; set; }
    }
}