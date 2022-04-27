using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Design.Infra.Data.Tables;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Person.Infra.Tables
{

    /// <summary>
    /// User table entity
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Class to map database table in EntityFramework")]
    public class User : TableIdBase<Guid, User>, ITable, IActive, IFullName
    {

        #region Constructors

        /// <summary>
        /// Create a new user instance
        /// </summary>
        public User() : base(Guid.NewGuid())
        {
            Initialize();
        }

        /// <summary>
        /// Create a new user instance
        /// </summary>
        /// <param name="id">User id value</param>
        public User(Guid id) : base(id)
        {
            Initialize();
        }

        /// <summary>
        /// Create a new user instance
        /// </summary>
        /// <param name="id">User id text</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public User(string id) : base()
        {
            Id = new Guid(id);
        }

        #endregion

        #region Properties

        /// <summary>
        /// User first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Active status flag
        /// </summary>
        public bool IsActive { get; set; }

        #endregion

        #region Navigation/Lazy

        /// <summary>
        /// Persons created by user
        /// </summary>
        public virtual ICollection<Person> CreatedPersons { get; set; }

        /// <summary>
        /// Persons changed by user
        /// </summary>
        public virtual ICollection<Person> ChangedPersons { get; set; }

        #endregion

        #region Local methods

        /// <summary>
        /// Iniatialize objects/properties/fields with default values
        /// </summary>
        private void Initialize()
        {
            IsActive = true;
            CreatedPersons = new HashSet<Person>();
            ChangedPersons = new HashSet<Person>();
        }

        #endregion

        #region Public methods

        ///<inheritdoc/>
        public string GetFullName()
            => $"{FirstName} {LastName}";

        #endregion

    }

}