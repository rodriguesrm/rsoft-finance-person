using RSoft.Lib.Design.Infra.Data.Tables;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Person.Infra.Tables
{

    /// <summary>
    /// Address type table entity
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Class to map database table in EntityFramework")]
    public class AddressType : TableBase<AddressType>, ITable
    {

        #region Constructors

        /// <summary>
        /// Create a new table instance
        /// </summary>
        public AddressType() : this(default) { }

        /// <summary>
        /// Create a new table instance
        /// </summary>
        /// <param name="id">Address type id value</param>
        public AddressType(byte id) 
        { 
            Id = id;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Address type id key value
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        /// Address type description 
        /// </summary>
        public int Description { get; set; }

        #endregion

        #region Navigation/Lazy

        /// <summary>
        /// Person data
        /// </summary>
        public virtual ICollection<PersonAddress> Addresses { get; set; }

        #endregion

    }
}
