using RSoft.Lib.Design.Domain.Services;
using System;

namespace RSoft.Person.Core.Ports
{

    /// <summary>
    /// Person domain service interface
    /// </summary>
    public interface IPersonDomainService : IDomainServiceBase<Entities.Person, Guid>
    {
    }
}
