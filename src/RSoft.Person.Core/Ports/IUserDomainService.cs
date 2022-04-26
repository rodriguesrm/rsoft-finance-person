using RSoft.Lib.Design.Domain.Services;
using RSoft.Person.Core.Entities;
using System;

namespace RSoft.Person.Core.Ports
{

    /// <summary>
    /// User domain service interface
    /// </summary>
    public interface IUserDomainService : IDomainServiceBase<User, Guid>
    {
    }
}
