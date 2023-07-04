using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSoft.Person.Infra.Tables;

namespace RSoft.Person.Infra.Configurations
{

    /// <summary>
    /// Person phone table configuration
    /// </summary>
    public class PersonPhoneConfiguration : IEntityTypeConfiguration<PersonPhone>
    {

        ///<inheritdoc/>
        public void Configure(EntityTypeBuilder<PersonPhone> builder)
        {

            builder.ToTable(nameof(PersonPhone));

            #region PK

            builder.HasKey(k => k.Id);

            #endregion

            #region Columns

            builder.Property(c => c.PersonId)
                .HasColumnName(nameof(PersonPhone.PersonId))
                .IsRequired();

            builder.Property(c => c.PhoneType)
                .HasColumnName(nameof(PersonPhone.PhoneType))
                .IsRequired();

            builder.Property(c => c.CountryCode)
                .HasColumnName(nameof(PersonPhone.CountryCode))
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.CityCode)
                .HasColumnName(nameof(PersonPhone.CityCode))
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.PhoneNumber)
                .HasColumnName(nameof(PersonPhone.PhoneNumber))
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.IsDefault)
                .HasColumnName(nameof(PersonPhone.IsDefault))
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();

            #endregion

            #region FKs

            builder.HasOne(o => o.Person)
                .WithMany(d => d.Phones)
                .HasForeignKey(fk => fk.PersonId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"FK_{nameof(Tables.Person)}_{nameof(PersonPhone)}_{nameof(PersonPhone.PersonId)}");

            #endregion

            #region Indexes

            builder
                .HasIndex(i => new { i.PersonId, i.CountryCode, i.CityCode, i.PhoneNumber })
                .HasDatabaseName($"AK_{nameof(PersonPhone)}_{nameof(Person)}_Full{nameof(PersonPhone.PhoneNumber)}")
                .IsUnique();

            #endregion

        }

    }

}
