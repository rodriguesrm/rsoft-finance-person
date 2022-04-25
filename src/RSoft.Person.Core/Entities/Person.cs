using RSoft.Lib.Common.Contracts;
using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Design.Domain.Entities;
using System;

namespace RSoft.Person.Core.Entities
{
    
    /// <summary>
    /// Person entity
    /// </summary>
    public class Person : EntityIdAuditBase<Guid, Person>, IEntity, IActive
    {

        #region Constructors

        /// <summary>
        /// Create a new person instance
        /// </summary>
        public Person() : base(Guid.NewGuid())
        {
            Initialize();
        }

        /// <summary>
        /// Create a new person instance
        /// </summary>
        /// <param name="id">Person id value</param>
        public Person(Guid id) : base(id)
        {
            Initialize();
        }

        /// <summary>
        /// Create a new person instance
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

        /// <summary>
        /// Person full name
        /// </summary>
        public Name Name { get; set; } = new Name(string.Empty, string.Empty);

        public string StreetName { get; set; }

        public string AddressNumber { get; set; }

        public string SecondaryAddress { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        #endregion

    }
}
