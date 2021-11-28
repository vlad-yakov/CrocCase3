using DataModel.Models.Duty;
using DataModel.Models.Linker;
using DataModel.Models.Project;
using DataModel.Models.User;

namespace DataModel
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class DataContext : DbContext
    {
        public DbSet<LinkerUserProject> Linker { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<DutyModel> Duties { get; set; }

        
        public DataContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DutyConfig());
            modelBuilder.ApplyConfiguration(new LinkerConfig());
            modelBuilder.ApplyConfiguration(new ProjectConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-MTELQ77I;database=CrocCase3v7;uid=root;password=root;");
        }
    }
}