using Microsoft.EntityFrameworkCore;
using RSoft.Lib.Design.Infra.Data;
using RSoft.Person.Infra.Configurations;
using RSoft.Person.Infra.Tables;
using System;
using System.Diagnostics.CodeAnalysis;
//using RSoft.Person.Infra.Tables;

namespace RSoft.Person.Infra
{

    /// <summary>
    /// Person database context
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "DbContext does not contains rules")]
    public class PersonContext : DbContextBase<Guid>
    {

        #region Constructors

        /// <summary>
        /// Create a new dbcontext instance
        /// </summary>
        /// <param name="options">Context options settings</param>
        public PersonContext(DbContextOptions options) : base(options) { }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        protected override void SetTableConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonAddressConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PersonNoteConfiguration());
            modelBuilder.ApplyConfiguration(new PersonTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        #endregion

        #region DbSets

        /// <summary>
        /// Person dbset
        /// </summary>
        public virtual DbSet<Tables.Person> Persons { get; set; }

        /// <summary>
        /// PersonAddress dbset
        /// </summary>
        public virtual DbSet<PersonAddress> PersonAddresses { get; set; }

        /// <summary>
        /// PersonNote dbset
        /// </summary>
        public virtual DbSet<PersonNote> PersonNotes { get; set; }

        /// <summary>
        /// PersonType dbset
        /// </summary>
        public virtual DbSet<PersonType> PersonTypes { get; set; }

        /// <summary>
        /// User dbset
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        #endregion


    }
}
