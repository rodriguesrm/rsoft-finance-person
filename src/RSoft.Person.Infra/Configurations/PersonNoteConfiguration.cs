using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSoft.Person.Infra.Tables;

namespace RSoft.Person.Infra.Configurations
{

    /// <summary>
    /// Person note table configuration
    /// </summary>
    public class PersonNoteConfiguration : IEntityTypeConfiguration<PersonNote>
    {

        ///<inheritdoc/>
        public void Configure(EntityTypeBuilder<PersonNote> builder)
        {

            builder.ToTable(nameof(PersonNote));

            #region PK

            builder.HasKey(k => k.PersonId);

            #endregion

            #region Columns

            builder.Property(c => c.Note)
                .HasColumnName(nameof(PersonNote.Note))
                .HasMaxLength(2000)
                .IsUnicode(false)
                .IsRequired();

            #endregion

            #region FKs

            builder.HasOne(o => o.Person)
                .WithOne(d => d.Note)
                .HasForeignKey<PersonNote>(fk => fk.PersonId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"FK_{nameof(Tables.Person)}_{nameof(PersonNote)}_{nameof(PersonNote.PersonId)}");

            #endregion

        }

    }

}
