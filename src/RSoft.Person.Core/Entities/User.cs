using RSoft.Lib.Design.Domain.Entities;
using System;

namespace RSoft.Person.Core.Entities
{

    /// <summary>
    /// User entity
    /// </summary>
    public class User : UserBase<User> 
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
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.OverflowException"></exception>
        public User(string id) : base(new Guid(id)) { }

        #endregion

    }
}
