using RSoft.Lib.Design.Infra.Data.Tables;
using RSoft.Person.Infra.Enum;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Person.Infra.Tables
{

    /// <summary>
    /// Person phone table entity
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Class to map database table in EntityFramework")]
    public class PersonPhone : TableIdBase<Guid, PersonPhone>, ITable
    {

        #region Constructors

        /// <summary>
        /// Create a new <see cref="PersonPhone"/> instance
        /// </summary>
        public PersonPhone() : base(Guid.NewGuid()) { }

        /// <summary>
        /// Create a new <see cref="PersonPhone"/> instance
        /// </summary>
        /// <param name="id">Person phone id value</param>
        public PersonPhone(Guid id) : base(id) { }

        /// <summary>
        /// Create a new <see cref="PersonPhone"/> instance
        /// </summary>
        /// <param name="id">Person phone id text</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public PersonPhone(string id) : base()
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
        /// short
        /// </summary>
        public PhoneType PhoneType { get; set; }

        /// <summary>
        /// Phone number country code
        /// </summary>
        public string CountryCode { get; set; }
        
        /// <summary>
        /// Phone number city code
        /// </summary>
        public string CityCode { get; set; }
        
        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Indicates whether this is the primary contact phone
        /// </summary>
        public bool IsDefault { get; set; }

        #endregion

        #region Navigation/Lazy

        /// <summary>
        /// Person data
        /// </summary>
        public virtual Person Person { get; set; }

        #endregion

    }
}
