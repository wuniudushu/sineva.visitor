using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using VisitorSystem.EntityFrameworkCore;
using VisitorSystem.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace VisitorSystem.Web.Tests
{
    [DependsOn(
        typeof(VisitorSystemWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class VisitorSystemWebTestModule : AbpModule
    {
        public VisitorSystemWebTestModule(VisitorSystemEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VisitorSystemWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(VisitorSystemWebMvcModule).Assembly);
        }
    }
}