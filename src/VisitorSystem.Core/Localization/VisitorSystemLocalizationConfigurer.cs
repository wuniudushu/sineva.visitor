using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace VisitorSystem.Localization
{
    public static class VisitorSystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(VisitorSystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(VisitorSystemLocalizationConfigurer).GetAssembly(),
                        "VisitorSystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
