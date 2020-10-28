using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using SgfDevs.Permissions;
using SgfDevs.Groups;

namespace SgfDevs.Groups
{
    [RemoteService(IsEnabled = false)]
    [Authorize(SgfDevsPermissions.Groups.Default)]
    public class GroupAppService : ApplicationService, IGroupAppService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupAppService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public virtual async Task<PagedResultDto<GroupDto>> GetListAsync(GetGroupsInput input)
        {
            var totalCount = await _groupRepository.GetCountAsync(input.FilterText, input.Name, input.FacebookLink, input.TwitterLink, input.LinkedInLink, input.InstagramLink, input.YouTubeLink, input.TwitchLink, input.WebsiteLink, input.WebsiteTitle, input.LocationText, input.EstablishedDateText);
            var items = await _groupRepository.GetListAsync(input.FilterText, input.Name, input.FacebookLink, input.TwitterLink, input.LinkedInLink, input.InstagramLink, input.YouTubeLink, input.TwitchLink, input.WebsiteLink, input.WebsiteTitle, input.LocationText, input.EstablishedDateText, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<GroupDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Group>, List<GroupDto>>(items)
            };
        }

        public virtual async Task<GroupDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Group, GroupDto>(await _groupRepository.GetAsync(id));
        }

        [Authorize(SgfDevsPermissions.Groups.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _groupRepository.DeleteAsync(id);
        }

        [Authorize(SgfDevsPermissions.Groups.Create)]
        public virtual async Task<GroupDto> CreateAsync(GroupCreateDto input)
        {
            var group = ObjectMapper.Map<GroupCreateDto, Group>(input);

            group = await _groupRepository.InsertAsync(group, autoSave: true);
            return ObjectMapper.Map<Group, GroupDto>(group);
        }

        [Authorize(SgfDevsPermissions.Groups.Edit)]
        public virtual async Task<GroupDto> UpdateAsync(Guid id, GroupUpdateDto input)
        {
            var group = await _groupRepository.GetAsync(id);
            ObjectMapper.Map(input, group);
            group = await _groupRepository.UpdateAsync(group);
            return ObjectMapper.Map<Group, GroupDto>(group);
        }
    }
}
