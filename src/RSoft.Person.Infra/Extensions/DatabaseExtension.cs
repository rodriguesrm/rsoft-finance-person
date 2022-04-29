using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using RSoft.Lib.Design.Infra.Extensions;

namespace RSoft.Person.Infra.Extensions
{

    /// <summary>
    /// Database extensions
    /// </summary>
    public static class DatabaseExtension
    {

        /// <summary>
        /// Apply migration tool for Create/Update database
        /// </summary>
        /// <param name="app">Application builder object instance</param>
        /// <param name="logger">Logger object</param>
        [ExcludeFromCodeCoverage(Justification = "Migrations class are not tested")]
        public static IApplicationBuilder ApplyMigration(this IApplicationBuilder app, ILogger logger)
            => app.MigrateDatabase<PersonContext>(logger);

    }

}
