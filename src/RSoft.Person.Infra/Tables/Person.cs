using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Design.Infra.Data;
using RSoft.Lib.Design.Infra.Data.Tables;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Person.Infra.Tables
{

    /// <summary>
    /// Person table entity
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Class to map database table in EntityFramework")]
    public class Person : TableIdAuditBase<Guid, Person>, ITable, IActive, IFullName, IAuditNavigation<Guid, User>
    {

        #region Constructors

        /// <summary>
        /// Create a new Person instance
        /// </summary>
        public Person() : base(Guid.NewGuid())
        {
            Initialize();
        }

        /// <summary>
        /// Create a new Person instance
        /// </summary>
        /// <param name="id">Person id value</param>
        public Person(Guid id) : base(id)
        {
            Initialize();
        }

        /// <summary>
        /// Create a new Person instance
        /// </summary>
        /// <param name="id">Person id text</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public Person(string id) : base()
        {
            Id = new Guid(id);
        }

        #endregion

        #region Properties

        ///<inheritdoc/>
        public string FirstName { get; set; }

        ///<inheritdoc/>
        public string LastName { get; set; }

        /// <summary>
        /// Person phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Person's notes
        /// </summary>
        public string Note { get; set; }

        ///<inheritdoc/>
        public bool IsActive { get; set; }

        #endregion

        #region Navigation/Lazy

        /// <summary>
        /// Created author data
        /// </summary>
        public virtual User CreatedAuthor { get; set; }

        /// <summary>
        /// Changed author data
        /// </summary>
        public virtual User ChangedAuthor { get; set; }

        /// <summary>
        /// Person's types data
        /// </summary>
        public virtual ICollection<PersonType> Types { get; set; }

        /// <summary>
        /// Person's addresses data
        /// </summary>
        public virtual ICollection<PersonAddress> Addresses { get; set; }

        #endregion

        #region Local methods

        /// <summary>
        /// Iniatialize objects/properties/fields with default values
        /// </summary>
        private void Initialize()
        {
            IsActive = true;
            Addresses = new HashSet<PersonAddress>();
            Types = new HashSet<PersonType>();
        }

        #endregion

        #region Public methods

        ///<inheritdoc/>
        public string GetFullName()
            => $"{FirstName} {LastName}";

        #endregion

    }
}
