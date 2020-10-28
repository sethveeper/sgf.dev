import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetGroupsInput extends PagedAndSortedResultRequestDto {
    filterText: string;
    name?: string;
    facebookLink?: string;
    twitterLink?: string;
    linkedInLink?: string;
    instagramLink?: string;
    youTubeLink?: string;
    twitchLink?: string;
    websiteLink?: string;
    websiteTitle?: string;
    locationText?: string;
    establishedDateText?: string;
}

export interface GroupCreateDto {
    name: string;
    facebookLink?: string;
    twitterLink?: string;
    linkedInLink?: string;
    instagramLink?: string;
    youTubeLink?: string;
    twitchLink?: string;
    websiteLink?: string;
    websiteTitle?: string;
    locationText?: string;
    establishedDateText?: string;
}

export interface GroupDto extends FullAuditedEntityDto<string> {
    name: string;
    facebookLink?: string;
    twitterLink?: string;
    linkedInLink?: string;
    instagramLink?: string;
    youTubeLink?: string;
    twitchLink?: string;
    websiteLink?: string;
    websiteTitle?: string;
    locationText?: string;
    establishedDateText?: string;
}

export interface GroupUpdateDto {
    name: string;
    facebookLink?: string;
    twitterLink?: string;
    linkedInLink?: string;
    instagramLink?: string;
    youTubeLink?: string;
    twitchLink?: string;
    websiteLink?: string;
    websiteTitle?: string;
    locationText?: string;
    establishedDateText?: string;
}
