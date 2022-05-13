using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Configuration;
using VisitorSystem.Web;

namespace VisitorSystem.EntityFrameworkCore
{
    public class ConnectionStringResolver : DefaultConnectionStringResolver
    {
        public ConnectionStringResolver(IAbpStartupConfiguration configuration)
           : base(configuration)
        {
        }

        public override string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            var connectStringName = this.GetConnectionStringName(args);
            if (connectStringName != null)
            {
                var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
                return configuration.GetConnectionString(connectStringName);
            }
            return base.GetNameOrConnectionString(args);
        }

        private string GetConnectionStringName(ConnectionStringResolveArgs args)
        {
            var type = args["DbContextConcreteType"] as Type;
            if (type == typeof(OADbContext))
            {
                return VisitorSystemConsts.ConnectionStringOA;
            }
            else if (type == typeof(OADbContext))
            {
                return VisitorSystemConsts.ConnectionStringOA;
            }
            return VisitorSystemConsts.ConnectionStringName;//采用默认数据库
        }
    }
}
