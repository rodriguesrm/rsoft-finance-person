using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RSoft.Person.Infra.Configurations
{

    /// <summary>
    /// Person table configuration
    /// </summary>
    public class PersonConfiguration : IEntityTypeConfiguration<Tables.Person>
    {

        ///<inheritdoc/>
        public void Configure(EntityTypeBuilder<Tables.Person> builder)
        {

            builder.ToTable(nameof(Tables.Person));

            #region PK

            builder.HasKey(k => k.Id);

            #endregion

            #region Columns

            builder.Property(c => c.FirstName)
                .HasColumnName(nameof(Tables.Person.FirstName))
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnName(nameof(Tables.Person.LastName))
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.PhoneNumber)
                .HasColumnName(nameof(Tables.Person.PhoneNumber))
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(c => c.Note)
                .HasColumnName(nameof(Tables.Person.Note))
                .HasMaxLength(2000)
                .IsUnicode(false);

            #endregion

            #region FKs

            builder.HasOne(s => s.CreatedAuthor)
                .WithMany(t => t.CreatedPersons)
                .HasForeignKey(fk => fk.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Tables.User)}_{nameof(Tables.Person)}_{nameof(Tables.Person.CreatedBy)}");

            builder.HasOne(o => o.ChangedAuthor)
                .WithMany(d => d.ChangedPersons)
                .HasForeignKey(fk => fk.ChangedBy)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Tables.User)}_{nameof(Tables.Person)}_{nameof(Tables.Person.ChangedBy)}");

            #endregion

            #region Indexes

            builder
                .HasIndex(i => new { i.FirstName, i.LastName })
                .HasDatabaseName($"IX_{nameof(Tables.Person)}_FullName");

            #endregion

        }
    }
}
