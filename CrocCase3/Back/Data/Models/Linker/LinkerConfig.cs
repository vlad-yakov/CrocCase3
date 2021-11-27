using DataModel.Models.Duty;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Models.Linker
{
    /// <summary>
    /// Задает правила и свойства таблицы линкера.
    /// </summary>
    public class LinkerConfig : IEntityTypeConfiguration<LinkerUserProject>
    {
        /// <summary>
        /// Устанавливает правила и свойства таблицы..
        /// </summary>
        /// <param name="builder">Обьект для изменения свойств таблицы.</param>
        public void Configure(EntityTypeBuilder<LinkerUserProject> builder)
        {
            builder.ToTable("Linker");
            builder.HasKey(p => p.Id);
        }
    }
}