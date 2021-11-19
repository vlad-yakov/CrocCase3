using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Models.Project
{
    /// <summary>
    /// Задает правила и свойства таблицы проектов.
    /// </summary>
    public class ProjectConfig : IEntityTypeConfiguration<ProjectModel>
    {
        /// <summary>
        /// Устанавливает правила и свойства таблицы..
        /// </summary>
        /// <param name="builder">Обьект для изменения свойств таблицы.</param>
        public void Configure(EntityTypeBuilder<ProjectModel> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.Linker)
                .WithOne(t => t.Project)
                .HasForeignKey(p => p.ProjectId)
                .HasPrincipalKey(t=>t.Id);
        }
    }
}