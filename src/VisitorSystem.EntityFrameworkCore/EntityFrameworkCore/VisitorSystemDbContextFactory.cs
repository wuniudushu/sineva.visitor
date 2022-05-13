using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using VisitorSystem.Configuration;
using VisitorSystem.Web;

namespace VisitorSystem.EntityFrameworkCore
{
    public abstract class DbContextFactory<T> : IDesignTimeDbContextFactory<T> where T : AbpDbContext
    {
        public abstract string ConnectionStringName { get; }
        public abstract T CreateDbContext(string[] args);
    }
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class VisitorSystemDbContextFactory : DbContextFactory<VisitorSystemDbContext>
    {
        public override string ConnectionStringName {
            get { return VisitorSystemConsts.ConnectionStringName; }
        }

        public override VisitorSystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<VisitorSystemDbContext>();

            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            VisitorSystemDbContextConfigurer<VisitorSystemDbContext>.Configure(builder, configuration.GetConnectionString(VisitorSystemConsts.ConnectionStringName));

            return new VisitorSystemDbContext(builder.Options);
        }

        public class OADbContextFactory : DbContextFactory<OADbContext>
        {
            public override string ConnectionStringName
            {
                get { return VisitorSystemConsts.ConnectionStringOA; }
            }

            public override OADbContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<OADbContext>();

                /*
                 You can provide an environmentName parameter to the AppConfigurations.Get method. 
                 In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
                 Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
                 https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
                 */
                var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

                OADbContextConfigurer<OADbContext>.Configure(builder, configuration.GetConnectionString(VisitorSystemConsts.ConnectionStringOA));

                return new OADbContext(builder.Options);
            }
        }
    }
        
}
