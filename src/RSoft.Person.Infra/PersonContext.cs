using Microsoft.EntityFrameworkCore;
using RSoft.Lib.Design.Infra.Data;
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
            //modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }

        #endregion

        #region DbSets

        /// <summary>
        /// Person dbset
        /// </summary>
        //public virtual DbSet<Person> Entries { get; set; }

        #endregion


    }
}
