using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using VisitorSystem.Authorization;

namespace VisitorSystem
{
    [DependsOn(
        typeof(VisitorSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class VisitorSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<VisitorSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(VisitorSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
