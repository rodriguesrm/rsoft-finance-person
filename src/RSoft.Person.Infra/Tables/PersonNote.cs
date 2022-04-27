using RSoft.Lib.Design.Infra.Data.Tables;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Person.Infra.Tables
{

    /// <summary>
    /// Person's note table entity
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Class to map database table in EntityFramework")]
    public class PersonNote : TableBase<PersonNote>, ITable
    {

        #region Properties

        /// <summary>
        /// Person id key value
        /// </summary>
        public Guid? PersonId { get; set; }

        /// <summary>
        /// Notes about the person
        /// </summary>
        public string Note { get; set; }

        #endregion

        #region Navigation/Lazy

        /// <summary>
        /// Person data
        /// </summary>
        public virtual Person Person { get; set; }

        #endregion

    }
}
