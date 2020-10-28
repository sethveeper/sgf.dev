using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SgfDevs.Groups
{
    public interface IGroupAppService : IApplicationService
    {
        Task<PagedResultDto<GroupDto>> GetListAsync(GetGroupsInput input);

        Task<GroupDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<GroupDto> CreateAsync(GroupCreateDto input);

        Task<GroupDto> UpdateAsync(Guid id, GroupUpdateDto input);
    }
}
