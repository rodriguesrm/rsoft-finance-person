using RSoft.Lib.Design.Infra.Data.Tables;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Person.Infra.Tables
{

    /// <summary>
    /// Address person table entity
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Class to map database table in EntityFramework")]
    public class PersonAddress : TableIdBase<Guid, PersonAddress>, ITable
    {

        #region Constructors

        /// <summary>
        /// Create a new table instance
        /// </summary>
        public PersonAddress() : base(Guid.NewGuid()) { }

        /// <summary>
        /// Create a new table instance
        /// </summary>
        /// <param name="id">User id value</param>
        public PersonAddress(Guid id) : base(id) { }

        /// <summary>
        /// Create a new person instance
        /// </summary>
        /// <param name="id">Person id text</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public PersonAddress(string id) : base()
        {
            Id = new Guid(id);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Person id key value
        /// </summary>
        public Guid? PersonId { get; set; }

        /// <summary>
        /// Person-Address title
        /// </summary>
        public string Title { get; set; }

        ///<inheritdoc/>
        public string StreetName { get; set; }

        ///<inheritdoc/>
        public string AddressNumber { get; set; }

        ///<inheritdoc/>
        public string SecondaryAddress { get; set; }

        ///<inheritdoc/>
        public string District { get; set; }

        ///<inheritdoc/>
        public string City { get; set; }

        ///<inheritdoc/>
        public string State { get; set; }

        ///<inheritdoc/>
        public string ZipCode { get; set; }

        #endregion

        #region Navigation/Lazy

        /// <summary>
        /// Person data
        /// </summary>
        public virtual Person Person { get; set; }

        #endregion

    }

}
