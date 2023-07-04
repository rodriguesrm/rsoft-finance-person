using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSoft.Person.Infra.Tables;

namespace RSoft.Person.Infra.Configurations
{

    /// <summary>
    /// Address type table configuration
    /// </summary>
    public class AddressTypeConfiguration : IEntityTypeConfiguration<AddressType>
    {

        ///<inheritdoc/>
        public void Configure(EntityTypeBuilder<AddressType> builder)
        {

            builder.ToTable(nameof(AddressType));

            #region PK

            builder.HasKey(k => k.Id);

            #endregion

            #region Columns

            builder.Property(c => c.Description)
                .HasColumnName(nameof(AddressType.Description))
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();

            #endregion

            #region Indexes

            builder
                .HasIndex(i => i.Description)
                .HasDatabaseName($"AK_{nameof(AddressType)}_{nameof(AddressType.Description)}")
                .IsUnique();

            #endregion

        }

    }

}
