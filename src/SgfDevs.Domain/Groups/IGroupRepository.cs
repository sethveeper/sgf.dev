using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SgfDevs.Groups
{
    public interface IGroupRepository : IRepository<Group, Guid>
    {
        Task<List<Group>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}
