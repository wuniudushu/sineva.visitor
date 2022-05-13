using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using VisitorSystem.Configuration;

namespace VisitorSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(VisitorSystemWebCoreModule))]
    public class VisitorSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public VisitorSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VisitorSystemWebHostModule).GetAssembly());
        }
    }
}
