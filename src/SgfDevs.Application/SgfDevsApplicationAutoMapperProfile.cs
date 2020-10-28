using AutoMapper;
using SgfDevs.Groups;
using Volo.Abp.AutoMapper;

namespace SgfDevs
{
    public class SgfDevsApplicationAutoMapperProfile : Profile
    {
        public SgfDevsApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<GroupCreateDto, Group>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<GroupUpdateDto, Group>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Group, GroupDto>();
        }
    }
}
