using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using SgfDevs.EntityFrameworkCore;

namespace SgfDevs.Groups
{
    public class EfCoreGroupRepository : EfCoreRepository<SgfDevsDbContext, Group, Guid>, IGroupRepository
    {
        public EfCoreGroupRepository(IDbContextProvider<SgfDevsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Group>> GetListAsync(
            string filterText = null,
            string name = null,
            string facebookLink = null,
            string twitterLink = null,
            string linkedInLink = null,
            string instagramLink = null,
            string youTubeLink = null,
            string twitchLink = null,
            string websiteLink = null,
            string websiteTitle = null,
            string locationText = null,
            string establishedDateText = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, name, facebookLink, twitterLink, linkedInLink, instagramLink,
                youTubeLink, twitchLink, websiteLink, websiteTitle, locationText, establishedDateText);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? GroupConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            string facebookLink = null,
            string twitterLink = null,
            string linkedInLink = null,
            string instagramLink = null,
            string youTubeLink = null,
            string twitchLink = null,
            string websiteLink = null,
            string websiteTitle = null,
            string locationText = null,
            string establishedDateText = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, name, facebookLink, twitterLink, linkedInLink, instagramLink,
                youTubeLink, twitchLink, websiteLink, websiteTitle, locationText, establishedDateText);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Group> ApplyFilter(
            IQueryable<Group> query,
            string filterText,
            string name = null,
            string facebookLink = null,
            string twitterLink = null,
            string linkedInLink = null,
            string instagramLink = null,
            string youTubeLink = null,
            string twitchLink = null,
            string websiteLink = null,
            string websiteTitle = null,
            string locationText = null,
            string establishedDateText = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText),
                    e => e.Name.Contains(filterText) || e.FacebookLink.Contains(filterText) ||
                         e.TwitterLink.Contains(filterText) || e.LinkedInLink.Contains(filterText) ||
                         e.InstagramLink.Contains(filterText) || e.YouTubeLink.Contains(filterText) ||
                         e.TwitchLink.Contains(filterText) || e.WebsiteLink.Contains(filterText) ||
                         e.WebsiteTitle.Contains(filterText) || e.LocationText.Contains(filterText) ||
                         e.EstablishedDateText.Contains(filterText))
                .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                .WhereIf(!string.IsNullOrWhiteSpace(facebookLink), e => e.FacebookLink.Contains(facebookLink))
                .WhereIf(!string.IsNullOrWhiteSpace(twitterLink), e => e.TwitterLink.Contains(twitterLink))
                .WhereIf(!string.IsNullOrWhiteSpace(linkedInLink), e => e.LinkedInLink.Contains(linkedInLink))
                .WhereIf(!string.IsNullOrWhiteSpace(instagramLink), e => e.InstagramLink.Contains(instagramLink))
                .WhereIf(!string.IsNullOrWhiteSpace(youTubeLink), e => e.YouTubeLink.Contains(youTubeLink))
                .WhereIf(!string.IsNullOrWhiteSpace(twitchLink), e => e.TwitchLink.Contains(twitchLink))
                .WhereIf(!string.IsNullOrWhiteSpace(websiteLink), e => e.WebsiteLink.Contains(websiteLink))
                .WhereIf(!string.IsNullOrWhiteSpace(websiteTitle), e => e.WebsiteTitle.Contains(websiteTitle))
                .WhereIf(!string.IsNullOrWhiteSpace(locationText), e => e.LocationText.Contains(locationText))
                .WhereIf(!string.IsNullOrWhiteSpace(establishedDateText),
                    e => e.EstablishedDateText.Contains(establishedDateText));
        }
    }
}
