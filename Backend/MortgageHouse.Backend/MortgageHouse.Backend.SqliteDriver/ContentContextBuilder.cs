using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MortgageHouse.Backend.Constants;

namespace MortgageHouse.Backend.SqliteDriver
{
    public class ContentContextBuilder : IDesignTimeDbContextFactory<ContentDb>
    {
        public ContentDb CreateDbContext(string[] args)
        {
            //Configure Sql Server as the Provider
            var builder = new DbContextOptionsBuilder<ContentDb>()
                   .UseSqlite(DbConstants.AccessConnectionString);

            return new ContentDb(builder.Options);
        }
    }
}
