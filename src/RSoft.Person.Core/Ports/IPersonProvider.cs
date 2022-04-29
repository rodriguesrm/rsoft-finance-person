using RSoft.Lib.Design.Infra.Data;
using System;

namespace RSoft.Person.Core.Ports
{

    /// <summary>
    /// Person provider interface port/contract
    /// </summary>
    public interface IPersonProvider : IRepositoryBase<Entities.Person, Guid> { }

}
