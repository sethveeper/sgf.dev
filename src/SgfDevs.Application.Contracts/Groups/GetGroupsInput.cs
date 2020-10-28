using Volo.Abp.Application.Dtos;
using System;

namespace SgfDevs.Groups
{
    public class GetGroupsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        public string InstagramLink { get; set; }
        public string YouTubeLink { get; set; }
        public string TwitchLink { get; set; }
        public string WebsiteLink { get; set; }
        public string WebsiteTitle { get; set; }
        public string LocationText { get; set; }
        public string EstablishedDateText { get; set; }

        public GetGroupsInput()
        {

        }
    }
}
