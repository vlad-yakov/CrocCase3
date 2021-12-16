using System.Collections.Generic;
using DataModel.Models.Duty;
using DataModel.Models.Project;
using DataModel.Models.User;

namespace DataModel.Models.Linker
{
    /// <summary>
    /// Описывает связующую таблицу между пользователем и проектом, в котором он состоит, а также указывает его роль в данном проекте.
    /// </summary>
    public class LinkerUserProject
    {
        /// <summary>
        /// Идентификатор линкера.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Идентификатор проекта.
        /// </summary>
        public int ProjectId { get; set; }
        
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Роль пользователя в проекте.(0 - участник проекта, 99 - администратор проекта)
        /// </summary>
        public int RoleType { get; set; }

        /// <summary>
        /// Связанный проект.
        /// </summary>
        public ProjectModel Project { get; set; }
        
        /// <summary>
        /// Связанный пользователь.
        /// </summary>
        public UserModel User { get; set; }
        
        /// <summary>
        /// Показывает удалили ли элемент.
        /// </summary>
        public bool Deleted { get; set; }
        
        /// <summary>
        /// Список смен, связанных с этой строкой.
        /// </summary>
        public List<DutyModel> Duty { get; set; }
    }
}