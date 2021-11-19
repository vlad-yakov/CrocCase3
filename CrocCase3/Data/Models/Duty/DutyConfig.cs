using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Models.Duty
{
    /// <summary>
    /// Задает правила и свойства таблицы смен.
    /// </summary>
    public class DutyConfig : IEntityTypeConfiguration<DutyModel>
    {
        /// <summary>
        /// Устанавливает правила и свойства таблицы..
        /// </summary>
        /// <param name="builder">Обьект для изменения свойств таблицы.</param>
        public void Configure(EntityTypeBuilder<DutyModel> builder)
        {
            builder.ToTable("Duties");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Linker)
                .WithMany(t => t.Duty)
                .HasForeignKey(p => p.LinkerId)
                .HasPrincipalKey(t=>t.Id);
        }
    }
}