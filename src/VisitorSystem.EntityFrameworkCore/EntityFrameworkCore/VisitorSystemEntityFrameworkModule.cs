using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using VisitorSystem.EntityFrameworkCore.Seed;

namespace VisitorSystem.EntityFrameworkCore
{
    [DependsOn(
        typeof(VisitorSystemCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class VisitorSystemEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            base.PreInitialize();
            Configuration.ReplaceService(typeof(IConnectionStringResolver), () =>
            {
                Configuration.ReplaceService<IConnectionStringResolver, ConnectionStringResolver>();

                // Configure first DbContext
                Configuration.Modules.AbpEfCore().AddDbContext<VisitorSystemDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        VisitorSystemDbContextConfigurer<VisitorSystemDbContext>.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        VisitorSystemDbContextConfigurer < VisitorSystemDbContext > .Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });

                // Configure second DbContext
                Configuration.Modules.AbpEfCore().AddDbContext<OADbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        OADbContextConfigurer<OADbContext>.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        OADbContextConfigurer<OADbContext> .Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });

            });
            //if (!SkipDbContextRegistration)
            //{
            //    Configuration.Modules.AbpEfCore().AddDbContext<VisitorSystemDbContext>(options =>
            //    {
            //        if (options.ExistingConnection != null)
            //        {
            //            VisitorSystemDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
            //        }
            //        else
            //        {
            //            VisitorSystemDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
            //        }
            //    });
            //}
        }
      
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VisitorSystemEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
