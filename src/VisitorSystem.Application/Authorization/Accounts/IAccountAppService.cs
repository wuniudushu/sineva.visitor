using System.Threading.Tasks;
using Abp.Application.Services;
using VisitorSystem.Authorization.Accounts.Dto;

namespace VisitorSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
