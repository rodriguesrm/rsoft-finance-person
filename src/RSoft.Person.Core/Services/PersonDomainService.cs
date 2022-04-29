using RSoft.Lib.Common.Contracts.Web;
using RSoft.Lib.Common.ValueObjects;
using RSoft.Lib.Design.Domain.Services;
using RSoft.Person.Core.Ports;
using System;

namespace RSoft.Person.Core.Services
{

    /// <summary>
    /// Person domain service operations
    /// </summary>
    public class PersonDomainService : DomainServiceBase<Entities.Person, Guid, IPersonProvider>, IPersonDomainService
    {

        #region Constructors

        /// <summary>
        /// Create a new person domain service instance
        /// </summary>
        /// <param name="provider">Person provider</param>
        /// <param name="authenticatedUser">Authenticated user object</param>
        public PersonDomainService(IPersonProvider provider, IAuthenticatedUser authenticatedUser) : base(provider, authenticatedUser) { }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        public override void PrepareSave(Entities.Person entity, bool isUpdate)
        {
            if (isUpdate)
            {
                if (entity.ChangedAuthor == null)
                {
                    entity.ChangedAuthor = new AuthorNullable<Guid>(_authenticatedUser.Id.Value, $"{_authenticatedUser.FirstName} {_authenticatedUser.LastName}");
                    entity.ChangedOn = DateTime.UtcNow;
                }
            }
            else
            {
                entity.CreatedAuthor = new Author<Guid>(_authenticatedUser.Id.Value, $"{_authenticatedUser.FirstName} {_authenticatedUser.LastName}");
                entity.CreatedOn = DateTime.UtcNow;
            }
        }

        #endregion

    }
}
