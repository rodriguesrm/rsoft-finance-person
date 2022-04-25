using RSoft.Lib.Common.Contracts;
using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Design.Domain.Entities;
using System;

namespace RSoft.Person.Core.Entities
{

    /// <summary>
    /// Type of person entity
    /// </summary>
    public class PersonType : EntityIdBase<Guid, PersonType>, IEntity, IActive
    {

        #region Constructors

        /// <summary>
        /// Create a new person type instance
        /// </summary>
        public PersonType() : base(Guid.NewGuid())
        {
            Initialize();
        }

        /// <summary>
        /// Create a new person type instance
        /// </summary>
        /// <param name="id">Person Type id value</param>
        public PersonType(Guid id) : base(id)
        {
            Initialize();
        }

        /// <summary>
        /// Create a new person type instance
        /// </summary>
        /// <param name="id">Person Type id text</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public PersonType(string id) : base()
        {
            Id = new Guid(id);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Person type name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicate if entity is active
        /// </summary>
        public bool IsActive { get; set; }

        #endregion

        #region Local Methods

        /// <summary>
        /// Iniatialize objects/properties/fields with default values
        /// </summary>
        private void Initialize()
        {
            IsActive = true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Validate entity
        /// </summary>
        public override void Validate()
        {
            AddNotifications(new SimpleStringValidationContract(Name, nameof(Name), true, 3, 50).Contract.Notifications);
        }

        #endregion

    }
}
