using Microsoft.EntityFrameworkCore;
using SgfDevs.Groups;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SgfDevs.EntityFrameworkCore
{
    public static class SgfDevsDbContextModelCreatingExtensions
    {
        public static void ConfigureSgfDevs(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(SgfDevsConsts.DbTablePrefix + "YourEntities", SgfDevsConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.Entity<Group>(b =>
            {
                b.ToTable(SgfDevsConsts.DbTablePrefix + "Groups", SgfDevsConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).HasColumnName(nameof(Group.Name)).IsRequired();
                b.Property(x => x.FacebookLink).HasColumnName(nameof(Group.FacebookLink));
                b.Property(x => x.TwitterLink).HasColumnName(nameof(Group.TwitterLink));
                b.Property(x => x.LinkedInLink).HasColumnName(nameof(Group.LinkedInLink));
                b.Property(x => x.InstagramLink).HasColumnName(nameof(Group.InstagramLink));
                b.Property(x => x.YouTubeLink).HasColumnName(nameof(Group.YouTubeLink));
                b.Property(x => x.TwitchLink).HasColumnName(nameof(Group.TwitchLink));
                b.Property(x => x.WebsiteLink).HasColumnName(nameof(Group.WebsiteLink));
                b.Property(x => x.WebsiteTitle).HasColumnName(nameof(Group.WebsiteTitle));
                b.Property(x => x.LocationText).HasColumnName(nameof(Group.LocationText));
                b.Property(x => x.EstablishedDateText).HasColumnName(nameof(Group.EstablishedDateText));
            });
        }
    }
}
