import type { GetGroupsInput, GroupCreateDto, GroupDto, GroupUpdateDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})
export class GroupService {
    apiName = 'Default';

    create = (input: GroupCreateDto) =>
        this.restService.request<any, GroupDto>({
                method: 'POST',
                url: `/api/app/groups`,
                body: input,
            },
            { apiName: this.apiName });

    delete = (id: string) =>
        this.restService.request<any, void>({
                method: 'DELETE',
                url: `/api/app/groups/${id}`,
            },
            { apiName: this.apiName });

    get = (id: string) =>
        this.restService.request<any, GroupDto>({
                method: 'GET',
                url: `/api/app/groups/${id}`,
            },
            { apiName: this.apiName });

    getList = (input: GetGroupsInput) =>
        this.restService.request<any, PagedResultDto<GroupDto>>({
                method: 'GET',
                url: `/api/app/groups`,
                params: {
                    filterText: input.filterText,
                    name: input.name,
                    facebookLink: input.facebookLink,
                    twitterLink: input.twitterLink,
                    linkedInLink: input.linkedInLink,
                    instagramLink: input.instagramLink,
                    youTubeLink: input.youTubeLink,
                    twitchLink: input.twitchLink,
                    websiteLink: input.websiteLink,
                    websiteTitle: input.websiteTitle,
                    locationText: input.locationText,
                    establishedDateText: input.establishedDateText,
                    sorting: input.sorting,
                    skipCount: input.skipCount,
                    maxResultCount: input.maxResultCount
                },
            },
            { apiName: this.apiName });

    update = (id: string, input: GroupUpdateDto) =>
        this.restService.request<any, GroupDto>({
                method: 'PUT',
                url: `/api/app/groups/${id}`,
                body: input,
            },
            { apiName: this.apiName });

    constructor(private restService: RestService) {
    }
}
