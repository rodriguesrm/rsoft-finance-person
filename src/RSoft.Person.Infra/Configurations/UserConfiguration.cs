using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSoft.Person.Infra.Tables;

namespace RSoft.Person.Infra.Configurations
{

    /// <summary>
    /// User table configuration
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        ///<inheritdoc/>
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable(nameof(User));

            #region PK

            builder.HasKey(k => k.Id);

            #endregion

            #region Columns

            builder.Property(c => c.FirstName)
                .HasColumnName(nameof(User.FirstName))
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnName(nameof(User.LastName))
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            #endregion

            #region Indexes

            builder
                .HasIndex(i => new { i.FirstName, i.LastName })
                .HasDatabaseName($"IX_{nameof(User)}_FullName");

            #endregion

        }
    }
}
