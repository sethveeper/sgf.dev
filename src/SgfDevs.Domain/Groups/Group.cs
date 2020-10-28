using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace SgfDevs.Groups
{
    public class Group : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string FacebookLink { get; set; }

        [CanBeNull]
        public virtual string TwitterLink { get; set; }

        [CanBeNull]
        public virtual string LinkedInLink { get; set; }

        [CanBeNull]
        public virtual string InstagramLink { get; set; }

        [CanBeNull]
        public virtual string YouTubeLink { get; set; }

        [CanBeNull]
        public virtual string TwitchLink { get; set; }

        [CanBeNull]
        public virtual string WebsiteLink { get; set; }

        [CanBeNull]
        public virtual string WebsiteTitle { get; set; }

        [CanBeNull]
        public virtual string LocationText { get; set; }

        [CanBeNull]
        public virtual string EstablishedDateText { get; set; }

        public Group()
        {

        }

        public Group(Guid id, string name, string facebookLink, string twitterLink, string linkedInLink, string instagramLink, string youTubeLink, string twitchLink, string websiteLink, string websiteTitle, string locationText, string establishedDateText)
        {
            Id = id;
            Check.NotNull(name, nameof(name));
            Name = name;
            FacebookLink = facebookLink;
            TwitterLink = twitterLink;
            LinkedInLink = linkedInLink;
            InstagramLink = instagramLink;
            YouTubeLink = youTubeLink;
            TwitchLink = twitchLink;
            WebsiteLink = websiteLink;
            WebsiteTitle = websiteTitle;
            LocationText = locationText;
            EstablishedDateText = establishedDateText;
        }
    }
}
