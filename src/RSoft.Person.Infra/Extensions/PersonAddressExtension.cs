using RSoft.Lib.Common.ValueObjects;
using System.Linq;
using System.Collections.Generic;
using PersonAddressDomain = RSoft.Person.Core.Entities.PersonAddress;
using PersonAddressTable = RSoft.Person.Infra.Tables.PersonAddress;

namespace RSoft.Person.Infra.Extensions
{

    /// <summary>
    /// Person address extensions
    /// </summary>
    public static class PersonAddressExtension
    {

        /// <summary>
        /// Maps tables to entities list
        /// </summary>
        /// <param name="tables">Tables entity to map</param>
        /// <param name="useLazy">Load related data</param>
        public static IList<PersonAddressDomain> Map(this IList<PersonAddressDomain> _, ICollection<PersonAddressTable> tables)
            => tables.Select(s => s.Map()).ToList();

        /// <summary>
        /// Maps table to entity
        /// </summary>
        /// <param name="table">Table entity to map</param>
        /// <param name="useLazy">Load related data</param>
        public static PersonAddressDomain Map(this PersonAddressTable table)
        {

            PersonAddressDomain result = null;

            if (table != null)
            {

                result = new PersonAddressDomain(table.Id)
                {
                    PersonId = table.PersonId,
                    Title = table.Title,
                    StreetName = table.StreetName,
                    AddressNumber = table.AddressNumber,
                    SecondaryAddress = table.SecondaryAddress,
                    District = table.District,
                    City = table.City,
                    State = table.State,
                    ZipCode = table.ZipCode
                };

            }

            return result;

        }

        /// <summary>
        /// Maps entity to table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        public static PersonAddressTable Map(this PersonAddressDomain entity)
        {

            PersonAddressTable result = null;

            if (entity != null)
            {

                result = new PersonAddressTable(entity.Id)
                {
                    PersonId = entity.PersonId,
                    Title = entity.Title,
                    StreetName = entity.StreetName,
                    AddressNumber = entity.AddressNumber,
                    SecondaryAddress = entity.SecondaryAddress,
                    District = entity.District,
                    City = entity.City,
                    State = entity.State,
                    ZipCode = entity.ZipCode
                };

            }

            return result;

        }

        /// <summary>
        /// Maps entity to an existing table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        /// <param name="table">Instance of existing table entity</param>
        public static PersonAddressTable Map(this PersonAddressDomain entity, PersonAddressTable table)
        {

            if (entity != null && table != null)
            {

                table.PersonId = entity.PersonId;
                table.Title = entity.Title;
                table.StreetName = entity.StreetName;
                table.AddressNumber = entity.AddressNumber;
                table.SecondaryAddress = entity.SecondaryAddress;
                table.District = entity.District;
                table.City = entity.City;
                table.State = entity.State;
                table.ZipCode = entity.ZipCode;

            }

            return table;

        }

    }

}
