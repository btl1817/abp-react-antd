using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Precise.ProductLine.Dto;
using Abp;
using Abp.Auditing;
using Abp.RealTime;
using Abp.Runtime.Session;
using Abp.Timing;
using System.Linq.Dynamic.Core;
using System.Linq;
using Abp.Authorization;
using Precise.Authorization.Users;

namespace Precise.ProductLine
{
    [AbpAuthorize]
    public class ProductLineService : PreciseAppServiceBase, IProductLineService
    {
        private readonly IRepository<ProductLineInfo, long> _productLine;
        public ProductLineService(IRepository<ProductLineInfo, long> productLine)
        {
            _productLine = productLine;
        }

        public Task<ProductLineInfoDto> Create(ProductLineInfoDto input)
        {
            throw new NotImplementedException();
        }

        public Task Delete(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductLineInfoDto> Get(EntityDto<long> input)
        {
            var query = await _productLine.GetAsync(input.Id);

            return ObjectMapper.Map<ProductLineInfoDto>(query);
        }

        public async Task<PagedResultDto<ProductLineInfoDto>> GetAll(ProductLineInfoInput input)
        {
            var query = _productLine.GetAll();

            query = query
                .WhereIf(!input.Code.IsNullOrWhiteSpace(), item => item.Code.Contains(input.Code))
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), item => item.Name.Contains(input.Name))
                .WhereIf(input.Type.HasValue, item => item.Type.Equals(input.Type.Value))
                ;

            var resultCount = await query.CountAsync();
            var results = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var productLineDtos = ObjectMapper.Map<IReadOnlyList<ProductLineInfoDto>>(results);

            return new PagedResultDto<ProductLineInfoDto>(resultCount, productLineDtos);
        }

        public Task<ProductLineInfoDto> Update(ProductLineInfoDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductLineInfoDto> GetById(EntityDto<long> input)
        {
            var query = await _productLine.GetAsync(input.Id);

            return ObjectMapper.Map<ProductLineInfoDto>(query);
        }

        public async Task<IEnumerable<ProductLineInfoDto>> GetBanburyingProductLineList(string input)
        {
            var query = _productLine.GetAll().Where(p => p.Type == ProductLineType.密炼);

            if (!input.IsNullOrWhiteSpace())
                query = query.Where(p => p.Name.Contains(input) || p.Code.Contains(input));
            var results = await query
                .OrderBy(p => p.Code)
                .ToListAsync();
            return ObjectMapper.Map<IEnumerable<ProductLineInfoDto>>(results);
        }

    }
}
