using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using RSoft.Finance.Contracts.Enum;
using RSoft.Lib.Common.Abstractions;
using RSoft.Lib.Common.Contracts;
using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Common.ValueObjects;
using RSoft.Lib.Design.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public Person() : base(Guid.NewGuid()) { }

        /// <summary>
        /// Create a new person instance
        /// </summary>
        /// <param name="id">Person id value</param>
        public Person(Guid id) : base(id) { }

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

        /// <summary>
        /// Person phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        ///<inheritdoc/>
        public bool IsActive { get; set; }

        /// <summary>
        /// Notes about the person
        /// </summary>
        public string Note { get; set; }

        #endregion

        #region Navigation/Lazy

        /// <summary>
        /// List of addresses of this person
        /// </summary>
        public virtual IList<PersonAddress> Addresses { get; set; } = new List<PersonAddress>();

        public virtual IList<PersonTypeEnum> Types { get; set; } = new List<PersonTypeEnum>();

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

            AddNotifications(new SimpleStringValidationContract(Note, nameof(Note), false, 0, 2000).Contract.Notifications);

            int pos = 1;
            foreach (PersonAddress address in Addresses)
            {
                if (address != null)
                {
                    address.Validate();
                    if (address.Notifications.Count > 0)
                    {
                        foreach (FluentValidator.Notification notification in address.Notifications)
                        {
                            AddNotification($"Address-{pos}.{notification.Property}", notification.Message);
                        }
                    }
                }
                pos++;
            }

            IStringLocalizer<Person> localizer = ServiceActivator.GetScope().ServiceProvider.GetService<IStringLocalizer<Person>>();
            if (!Types.Any())
            {
                AddNotification(nameof(Types), localizer["ONE_TYPE_MUST_DEFINED"]);
            }
            else
            {
                pos = 1;
                foreach (PersonTypeEnum? type in Types)
                {
                    AddNotifications(new EnumCastFromIntegerValidationContract<PersonTypeEnum>((int)type, $"{nameof(Person)}{nameof(Types)}-{pos}", true).Contract.Notifications);
                    pos++;
                }
            }

        }

        #endregion

    }
}
