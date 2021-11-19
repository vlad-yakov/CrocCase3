using System;
using System.Collections.Generic;
using DataModel.Models.Linker;

namespace DataModel.Models.Project
{
    /// <summary>
    /// Описывает проект.
    /// </summary>
    public class ProjectModel
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
        
        /// <summary>
        /// Список связанных записей в линкере с этим проектом.
        /// </summary>
        public List<LinkerUserProject> Linker { get; set; }
    }
}