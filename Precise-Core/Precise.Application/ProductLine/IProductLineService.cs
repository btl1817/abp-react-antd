using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Precise.ProductLine.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Precise.ProductLine
{
    public interface IProductLineService : IAsyncCrudAppService<ProductLineInfoDto, long, ProductLineInfoInput>
    {
        Task<ProductLineInfoDto> GetById(EntityDto<long> input);
        Task<IEnumerable<ProductLineInfoDto>> GetBanburyingProductLineList(string input);
    }
}
