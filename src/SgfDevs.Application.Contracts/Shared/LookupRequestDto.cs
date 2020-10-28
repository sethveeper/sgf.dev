using Volo.Abp.Application.Dtos;

namespace SgfDevs.Shared
{
    public class LookupRequestDto : PagedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
