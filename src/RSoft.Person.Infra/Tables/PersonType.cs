using RSoft.Finance.Contracts.Enum;
using RSoft.Lib.Design.Infra.Data.Tables;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Person.Infra.Tables
{

    /// <summary>
    /// Person's types table entity
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Class to map database table in EntityFramework")]
    public class PersonType : TableBase<PersonType>, ITable
    {

        #region Properties

        /// <summary>
        /// Person id key value
        /// </summary>
        public Guid? PersonId { get; set; }

        /// <summary>
        /// Person type enum value
        /// </summary>
        public PersonTypeEnum? Type { get; set; }

        #endregion

        #region Navigation/Lazy

        /// <summary>
        /// Person data
        /// </summary>
        public virtual Person Person { get; set; }

        #endregion

    }
}
