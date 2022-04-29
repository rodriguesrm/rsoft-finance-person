using RSoft.Lib.Common.ValueObjects;
using UserDomain = RSoft.Person.Core.Entities.User;
using UserTable = RSoft.Person.Infra.Tables.User;

namespace RSoft.Person.Infra.Extensions
{
    
    /// <summary>
    /// User extensions
    /// </summary>
    public static class UserExtension
    {

        /// <summary>
        /// Maps table to entity
        /// </summary>
        /// <param name="table">Table entity to map</param>
        public static UserDomain Map(this UserTable table)
        {

            UserDomain result = null;

            if (table != null)
            {

                result = new UserDomain(table.Id)
                {
                    Name = new Name(table.FirstName, table.LastName),
                    IsActive = table.IsActive
                };

            }

            return result;

        }

        /// <summary>
        /// Maps entity to table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        public static UserTable Map(this UserDomain entity)
        {

            UserTable result = null;

            if (entity != null)
            {

                result = new UserTable(entity.Id)
                {
                    FirstName=entity.Name.FirstName,
                    LastName=entity.Name.LastName, 
                    IsActive=entity.IsActive
                };

            }

            return result;

        }

        /// <summary>
        /// Maps entity to an existing table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        /// <param name="table">Instance of existing table entity</param>
        public static UserTable Map(this UserDomain entity, UserTable table)
        {

            if (entity != null && table != null)
            {
                table.LastName = entity.Name.FirstName;
                table.LastName = entity.Name.LastName;
                table.IsActive = entity.IsActive;
            }

            return table;

        }

    }

}
