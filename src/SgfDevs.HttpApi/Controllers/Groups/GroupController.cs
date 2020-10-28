using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using SgfDevs.Groups;

namespace SgfDevs.Controllers.Groups
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Group")]
    [Route("api/app/groups")]
    public class GroupController : AbpController, IGroupAppService
    {
        private readonly IGroupAppService _groupAppService;

        public GroupController(IGroupAppService groupAppService)
        {
            _groupAppService = groupAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<GroupDto>> GetListAsync(GetGroupsInput input)
        {
            return _groupAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<GroupDto> GetAsync(Guid id)
        {
            return _groupAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<GroupDto> CreateAsync(GroupCreateDto input)
        {
            return _groupAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<GroupDto> UpdateAsync(Guid id, GroupUpdateDto input)
        {
            return _groupAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _groupAppService.DeleteAsync(id);
        }
    }
}
