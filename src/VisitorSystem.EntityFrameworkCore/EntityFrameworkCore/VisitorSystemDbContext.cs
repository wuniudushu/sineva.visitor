using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using VisitorSystem.Authorization.Roles;
using VisitorSystem.Authorization.Users;
using VisitorSystem.MultiTenancy;
using Abp.EntityFrameworkCore;
using VisitorSystem.VisitorsSystem.OASystem;
using VisitorSystem.VisitorEntity;
using VisitorSystem.VisitorsSystem.VisitorEntity;

namespace VisitorSystem.EntityFrameworkCore
{
    public class VisitorSystemDbContext : AbpZeroDbContext<Tenant, Role, User, VisitorSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<SinevaUser> SinevaUsers { get; set; }
        public DbSet<VisitorRecord> VisitorRecords { get;set;}  
        public VisitorSystemDbContext(DbContextOptions<VisitorSystemDbContext> options)
            : base(options)
        {
        }


        
    }
    public class OADbContext : AbpDbContext
    {
        /* Define a DbSet for each entity of the application */
        /* Define a DbSet for each entity of the application */
     //   public DbSet<OATest> OATests { get; set; }
     //   public DbSet<HrmResource> HrmResource { get; set; }

        public OADbContext(DbContextOptions<OADbContext> options)
            : base(options)
        {
        }

    }

}
