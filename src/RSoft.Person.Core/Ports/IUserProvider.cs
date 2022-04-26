using RSoft.Lib.Design.Infra.Data;
using RSoft.Person.Core.Entities;
using System;

namespace RSoft.Person.Core.Ports
{

    /// <summary>
    /// User provider interface port/contract
    /// </summary>
    public interface IUserProvider : IRepositoryBase<User, Guid>
    {
    }

}
