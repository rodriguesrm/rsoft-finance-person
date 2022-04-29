using RSoft.Lib.Common.ValueObjects;
using PersonDomain = RSoft.Person.Core.Entities.Person;
using PersonTable = RSoft.Person.Infra.Tables.Person;

namespace RSoft.Person.Infra.Extensions
{

    /// <summary>
    /// Person extensions
    /// </summary>
    public static class PersonExtension
    {

        /// <summary>
        /// Maps table to entity
        /// </summary>
        /// <param name="table">Table entity to map</param>
        public static PersonDomain Map(this PersonTable table)
            => table.Map(true);

        /// <summary>
        /// Maps table to entity
        /// </summary>
        /// <param name="table">Table entity to map</param>
        /// <param name="useLazy">Load related data</param>
        public static PersonDomain Map(this PersonTable table, bool useLazy)
        {

            PersonDomain result = null;

            if (table != null)
            {

                result = new PersonDomain(table.Id)
                {
                    Name = new Name(table.FirstName, table.LastName),
                    PhoneNumber = table.PhoneNumber,

                    CreatedOn = table.CreatedOn,
                    ChangedOn = table.ChangedOn,
                    IsActive = table.IsActive
                };

                if (useLazy)
                {
                    result.MapAuthor(table);
                    result.Addresses.Map(table.Addresses);
                    result.Note = table.Note;
                }

            }

            return result;

        }

        /// <summary>
        /// Maps entity to table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        public static PersonTable Map(this PersonDomain entity)
            => entity.Map(true);

        /// <summary>
        /// Maps entity to table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        /// <param name="useLazy">Load related data</param>
            public static PersonTable Map(this PersonDomain entity, bool useLazy)
        {

            PersonTable result = null;

            if (entity != null)
            {

                result = new PersonTable(entity.Id)
                {
                    FirstName = entity.Name.FirstName,
                    LastName = entity.Name.LastName,
                    PhoneNumber = entity.PhoneNumber,
                    Note = entity.Note,
                    IsActive = entity.IsActive,
                    CreatedOn = entity.CreatedOn,
                    CreatedBy = entity.CreatedAuthor.Id
                };

                if (useLazy)
                {
                    result.MapAuthor(entity);
                }

            }

            return result;

        }

        /// <summary>
        /// Maps entity to an existing table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        /// <param name="table">Instance of existing table entity</param>
        public static PersonTable Map(this PersonDomain entity, PersonTable table)
        {

            if (entity != null && table != null)
            {

                table.FirstName = entity.Name.FirstName;
                table.LastName = entity.Name.LastName;
                table.PhoneNumber = entity.PhoneNumber;
                table.IsActive = entity.IsActive;
                table.ChangedOn = entity.ChangedOn;
                table.ChangedBy = entity.ChangedAuthor.Id;

            }

            return table;

        }

    }

}