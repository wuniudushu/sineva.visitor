using System.Threading.Tasks;
using VisitorSystem.Configuration.Dto;

namespace VisitorSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
