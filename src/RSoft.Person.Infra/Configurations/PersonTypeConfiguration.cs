using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSoft.Person.Infra.Tables;

namespace RSoft.Person.Infra.Configurations
{

    /// <summary>
    /// Person Type table configuration
    /// </summary>
    public class PersonTypeConfiguration : IEntityTypeConfiguration<PersonType>
    {

        ///<inheritdoc/>
        public void Configure(EntityTypeBuilder<PersonType> builder)
        {

            builder.ToTable(nameof(PersonType));

            #region PK

            builder.HasKey(k => k.PersonId);

            #endregion

            #region Columns

            builder.Property(c => c.Type)
                .HasColumnName(nameof(PersonType.Type))
                .HasColumnType("tinyint")
                .IsRequired();

            #endregion

            #region FKs

            builder.HasOne(o => o.Person)
                .WithMany(d => d.Types)
                .HasForeignKey(fk => fk.PersonId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"FK_{nameof(Tables.Person)}_{nameof(PersonType)}_{nameof(PersonType.PersonId)}");

            #endregion

            #region Indexes

            builder.HasIndex(i => i.PersonId)
                .HasDatabaseName($"IX_{nameof(PersonType)}_{nameof(PersonType.PersonId)}");

            #endregion

        }

    }

}
