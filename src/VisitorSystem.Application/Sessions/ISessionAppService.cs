using System.Threading.Tasks;
using Abp.Application.Services;
using VisitorSystem.Sessions.Dto;

namespace VisitorSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
