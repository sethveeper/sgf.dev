using System;
using System.ComponentModel.DataAnnotations;

namespace SgfDevs.Groups
{
    public class GroupCreateDto
    {
        [Required]
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
    }
}
