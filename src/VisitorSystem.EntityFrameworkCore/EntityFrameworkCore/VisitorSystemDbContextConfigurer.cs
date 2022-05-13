using System.Data.Common;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VisitorSystem.EntityFrameworkCore
{
    public static class VisitorSystemDbContextConfigurer<T> where T : AbpDbContext
    {
        public static void Configure(DbContextOptionsBuilder<VisitorSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<VisitorSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
    public static class OADbContextConfigurer<T> where T : AbpDbContext
    {
        public static void Configure(DbContextOptionsBuilder<OADbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<OADbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
