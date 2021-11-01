using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        
        public List<ScheduleModel> Schedule { get; set; } 
    }
    
    // public class UserRole : IEntityTypeConfiguration<UserModel>
    // {
    //
    //     public void Configure(EntityTypeBuilder<UserModel> builder)
    //     {
    //         builder.HasKey(link => link.Id);
    //
    //         HasRequired(link => link.ConfigurationModel).WithMany(module => module.Links).HasForeignKey(link => link.ConfigurationId);
    //         HasRequired(link => link.Version).WithMany(module => module.Links).HasForeignKey(link => link.VersionId);        }
    // }
}