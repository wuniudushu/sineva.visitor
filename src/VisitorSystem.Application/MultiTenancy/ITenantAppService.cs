using Abp.Application.Services;
using VisitorSystem.MultiTenancy.Dto;

namespace VisitorSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

