namespace DataModel
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class DataContext : DbContext
    {
        public DbSet<EventModel> Events { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<ScheduleModel> Schedule { get; set; }
        public DbSet<UserModel> Users { get; set; }
        
        public DataContext()
        {
            Database.EnsureCreated();
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-MTELQ77I;database=CrocCase3v1;uid=root;password=root;");
        }
    }
}