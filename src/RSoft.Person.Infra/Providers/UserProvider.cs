using RSoft.Lib.Design.Infra.Data;
using RSoft.Person.Core.Ports;
using RSoft.Person.Infra.Extensions;
using System;
using UserDomain = RSoft.Person.Core.Entities.User;
using UserTable = RSoft.Person.Infra.Tables.User;

namespace RSoft.Person.Infra.Providers
{

    /// <summary>
    /// User provider
    /// </summary>
    public class UserProvider : RepositoryBase<UserDomain, UserTable, Guid>, IUserProvider
    {

        #region Constructors

        /// <summary>
        /// Create a new user provider instance
        /// </summary>
        /// <param name="ctx"></param>
        public UserProvider(PersonContext ctx) : base(ctx) { }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        protected override UserDomain Map(UserTable table)
            => table.Map();

        ///<inheritdoc/>
        protected override UserTable MapForAdd(UserDomain entity)
            => entity.Map();

        ///<inheritdoc/>
        protected override UserTable MapForUpdate(UserDomain entity, UserTable table)
            => entity.Map(table);

        #endregion

    }

}
