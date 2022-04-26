using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Person.Infra
{

    /// <summary>
    /// Person context factory
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Config class used only for generate migration")]
    public class PersonContextFactory : IDesignTimeDbContextFactory<PersonContext>
    {

        ///<inheritdoc/>
        public PersonContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=192.168.3.1;Port=3306;Database=rsoft_person;Uid=root;password=RR.MySqlDev;";
            DbContextOptions options = new DbContextOptionsBuilder().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).Options;
            return new PersonContext(options);
        }

    }
}
