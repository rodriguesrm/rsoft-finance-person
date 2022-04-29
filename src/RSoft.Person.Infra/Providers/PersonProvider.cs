using RSoft.Lib.Design.Infra.Data;
using RSoft.Person.Core.Ports;
using RSoft.Person.Infra.Extensions;
using System;
using PersonDomain = RSoft.Person.Core.Entities.Person;
using PersonTable = RSoft.Person.Infra.Tables.Person;

namespace RSoft.Person.Infra.Providers
{

    /// <summary>
    /// Person provider
    /// </summary>
    public class PersonProvider : RepositoryBase<PersonDomain, PersonTable, Guid>, IPersonProvider
    {

        #region Constructors

        /// <summary>
        /// Create a new person provider instance
        /// </summary>
        /// <param name="ctx"></param>
        public PersonProvider(PersonContext ctx) : base(ctx) { }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        protected override PersonDomain Map(PersonTable table)
            => table.Map();

        ///<inheritdoc/>
        protected override PersonTable MapForAdd(PersonDomain entity)
            => entity.Map();

        ///<inheritdoc/>
        protected override PersonTable MapForUpdate(PersonDomain entity, PersonTable table)
            => entity.Map(table);

        #endregion

    }

}
