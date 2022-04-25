using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Common.ValueObjects;
using RSoft.Lib.Design.Domain.Entities;
using System;

//TODO: Move this entity-class to RSoft.Lib.Design library
namespace RSoft.Person.Core.Entities
{

    /// <summary>
    /// User entity
    /// </summary>
    public class User : EntityIdBase<Guid, User>, IActive
    {

        #region Constructors

        /// <summary>
        /// Create a new user instance
        /// </summary>
        public User() : base(Guid.NewGuid()) { }

        /// <summary>
        /// Create a new user instance
        /// </summary>
        /// <param name="id">Category id value</param>
        public User(Guid id) : base(id) { }

        /// <summary>
        /// Create a new user instance
        /// </summary>
        /// <param name="id">Category id text</param>
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
        /// User full name
        /// </summary>
        public Name Name { get; set; } = new Name(string.Empty, string.Empty);

        /// <summary>
        /// Indicate if entity is active
        /// </summary>
        public bool IsActive { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Validate entity
        /// </summary>
        public override void Validate()
        {
            AddNotifications(Name.Notifications);
        }

        #endregion

    }
}
