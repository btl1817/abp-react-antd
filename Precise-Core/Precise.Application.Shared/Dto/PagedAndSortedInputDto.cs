using Abp.Application.Services.Dto;

namespace Precise.Dto
{
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        public string Sorting { get; set; }
        public string SortField { get; set; }
        public string SortOrder { get; set; }
        public PagedAndSortedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}