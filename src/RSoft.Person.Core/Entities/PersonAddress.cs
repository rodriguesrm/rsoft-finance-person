using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using RSoft.Lib.Common.Abstractions;
using RSoft.Lib.Common.Contracts;
using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Design.Domain.Entities;
using System;

namespace RSoft.Person.Core.Entities
{

    /// <summary>
    /// Person address entity
    /// </summary>
    public class PersonAddress : EntityIdBase<Guid, PersonAddress>, IEntity, IAddress
    {

        #region Constructors

        /// <summary>
        /// Create a new person-address instance
        /// </summary>
        public PersonAddress() : base(Guid.NewGuid()) { }

        /// <summary>
        /// Create a new person-address instance
        /// </summary>
        /// <param name="id">Person-Address id value</param>
        public PersonAddress(Guid id) : base(id) { }

        /// <summary>
        /// Create a new person-address instance
        /// </summary>
        /// <param name="id">Person-Address id text</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public PersonAddress(string id) : base(new Guid(id)) { }

        #endregion

        #region Properties

        /// <summary>
        /// Person id key value
        /// </summary>
        public Guid? PersonId { get; set; }

        /// <summary>
        /// Person-Address title
        /// </summary>
        public string Title { get; set; }

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

        #endregion

        #region Public methods

        ///<inheritdoc/>
        public override void Validate()
        {
            IStringLocalizer<PersonAddress> localizer = ServiceActivator.GetScope().ServiceProvider.GetService<IStringLocalizer<PersonAddress>>();
            AddNotifications(new RequiredValidationContract<Guid?>(PersonId, nameof(PersonId), localizer["PERSON_IS_REQUIRED"]).Contract.Notifications);
            AddNotifications(new SimpleStringValidationContract(Title, nameof(Title), true, 3, 40).Contract.Notifications);
            AddNotifications(new AddressValidationContract(this, false).Contract.Notifications);
        }

        #endregion

    }
}
