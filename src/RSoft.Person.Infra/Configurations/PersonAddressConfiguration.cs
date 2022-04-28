using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSoft.Person.Infra.Tables;

namespace RSoft.Person.Infra.Configurations
{

    /// <summary>
    /// Person Address table configuration
    /// </summary>
    public class PersonAddressConfiguration : IEntityTypeConfiguration<PersonAddress>
    {

        ///<inheritdoc/>
        public void Configure(EntityTypeBuilder<PersonAddress> builder)
        {

            builder.ToTable(nameof(PersonAddress));

            #region PK

            builder.HasKey(k => k.Id);

            #endregion

            #region Columns

            builder.Property(c => c.PersonId)
                .HasColumnName(nameof(PersonAddress.PersonId))
                .IsRequired();

            builder.Property(c => c.Title)
                .HasColumnName(nameof(PersonAddress.Title))
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.StreetName)
                .HasColumnName(nameof(PersonAddress.StreetName))
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(c => c.AddressNumber)
                .HasColumnName(nameof(PersonAddress.AddressNumber))
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(c => c.SecondaryAddress)
                .HasColumnName(nameof(PersonAddress.SecondaryAddress))
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(c => c.District)
                .HasColumnName(nameof(PersonAddress.District))
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(c => c.City)
                .HasColumnName(nameof(PersonAddress.City))
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(c => c.State)
                .HasColumnName(nameof(PersonAddress.State))
                .HasMaxLength(2)
                .IsUnicode(false);

            builder.Property(c => c.ZipCode)
                .HasColumnName(nameof(PersonAddress.ZipCode))
                .HasMaxLength(8)
                .IsUnicode(false);

            #endregion

            #region FKs

            builder.HasOne(o => o.Person)
                .WithMany(d => d.Addresses)
                .HasForeignKey(fk => fk.PersonId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"FK_{nameof(Tables.Person)}_{nameof(PersonAddress)}_{nameof(PersonAddress.PersonId)}");

            #endregion

            #region Indexes

            builder.HasIndex(i => i.PersonId)
                .HasDatabaseName($"IX_{nameof(PersonAddress)}_{nameof(PersonAddress.PersonId)}");

            builder.HasIndex(i => i.Title)
                .HasDatabaseName($"AK_{nameof(PersonAddress)}_{nameof(PersonAddress.Title)}")
                .IsUnique();

            #endregion

        }

    }

}
