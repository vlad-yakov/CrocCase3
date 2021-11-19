using System.Collections.Generic;
using DataModel.Models.Linker;

namespace DataModel.Models.User
{
    /// <summary>
    /// Описывает пользователя.
    /// </summary>
    public class UserModel
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
        /// Логин пользователя для авторизации.
        /// </summary>
        public string Login { get; set; }
        
        /// <summary>
        /// Пароль пользователя для авторизации.
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Список строк из линкера, связанных с данным пользователем.
        /// </summary>
        public List<LinkerUserProject> Linker { get; set; } 
    }
    
    // public class UserRole : IEntityTypeConfiguration<UserModel>
    // {
    //
    //     public void Configure(EntityTypeBuilder<UserModel> builder)
    //     {
    //         builder.HasKey(link => link.Id);
    //
    //         HasRequired(link => link.ConfigurationModel).WithMany(module => module.Links).HasForeignKey(link => link.ConfigurationId);
    //         HasRequired(link => link.Version).WithMany(module => module.Links).HasForeignKey(link => link.VersionId);
    //         
    //     }
    // }
}