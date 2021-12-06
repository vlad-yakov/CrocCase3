using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Models.User
{
    /// <summary>
    /// Задает правила и свойства таблицы пользователей.
    /// </summary>
    public class UserConfig : IEntityTypeConfiguration<UserModel>
    {
        /// <summary>
        /// Устанавливает правила и свойства таблицы..
        /// </summary>
        /// <param name="builder">Обьект для изменения свойств таблицы.</param>
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.Linker)
                .WithOne(t => t.User)
                .HasForeignKey(p => p.UserId)
                .HasPrincipalKey(t=>t.Id);
            builder.HasAlternateKey(u => u.Login);
        }
    }
}