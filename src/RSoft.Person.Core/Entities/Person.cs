using RSoft.Lib.Common.Contracts;
using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Common.ValueObjects;
using RSoft.Lib.Design.Domain.Entities;
using System;

namespace RSoft.Person.Core.Entities
{
    
    /// <summary>
    /// Person entity
    /// </summary>
    public class Person : EntityIdAuditBase<Guid, Person>, IEntity, IActive, IAddress
    {

        #region Constructors

        /// <summary>
        /// Create a new person instance
        /// </summary>
        public Person() : base(Guid.NewGuid())
        {
            //Initialize();
        }

        /// <summary>
        /// Create a new person instance
        /// </summary>
        /// <param name="id">Person id value</param>
        public Person(Guid id) : base(id)
        {
            //Initialize();
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

        ///<inheritdoc/>
        public string StreetName { get; set; }

        ///<inheritdoc/>
        public string AddressNumber { get; set; }

        ///<inheritdoc/>
        public string SecondaryAddress { get; set; }

        ///<inheritdoc/>
        public string District { get; set; }

        ///<inheritdoc/>
        public string City { get; set; }

        ///<inheritdoc/>
        public string State { get; set; }

        ///<inheritdoc/>
        public string ZipCode { get; set; }

        ///<inheritdoc/>
        public string PhoneNumber { get; set; }

        ///<inheritdoc/>
        public bool IsActive { get; set; }

        #endregion

        #region Public methods

        ///<inheritdoc/>
        public override void Validate()
        {

            AddNotifications(new FullNameValidationContract(Name, new FullNameValidationArgument()
            {
                FirstNameMinimumLength = 3,
                FirstNameMaximumLength = 50,
                LastNameMinimumLength = 3,
                LastNameMaximumLength = 100
            }).Contract.Notifications);
            AddNotifications(new AddressValidationContract(this, false).Contract.Notifications);

        }

        #endregion

    }
}
