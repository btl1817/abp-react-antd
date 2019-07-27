using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Precise.Technology.Dto;
using Abp;
using Abp.Auditing;
using Abp.RealTime;
using Abp.Runtime.Session;
using Abp.Timing;
using System.Linq.Dynamic.Core;
using Abp.Authorization;

namespace Precise.Technology
{
    [AbpAuthorize]
    public class TechnologyService : PreciseAppServiceBase, ITechnologyService
    {
        private readonly IRepository<TechnologyInfo, long> _TechnologyInfo;
        public TechnologyService(IRepository<TechnologyInfo, long> technologyInfo)
        {
            _TechnologyInfo = technologyInfo;
        }

        public Task<TechnologyInfoDto> Create(TechnologyInfoDto input)
        {
            throw new NotImplementedException();
        }

        public Task Delete(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public async Task<TechnologyInfoDto> Get(EntityDto<long> input)
        {
            var query = await _TechnologyInfo.GetAsync(input.Id);

            return ObjectMapper.Map<TechnologyInfoDto>(query);
        }

        public async Task<PagedResultDto<TechnologyInfoDto>> GetAll(GetTechnologyInfoInput input)
        {
            var query = _TechnologyInfo.GetAll();

            query = query
                .WhereIf(!input.Code.IsNullOrWhiteSpace(), item => item.Code.Contains(input.Code))
                .WhereIf(!input.RubberCode.IsNullOrWhiteSpace(), item => item.RubberCode.Contains(input.RubberCode));

            var resultCount = await query.CountAsync();
            var results = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var technologyInfoDtos = ObjectMapper.Map<IReadOnlyList<TechnologyInfoDto>>(results);

            return new PagedResultDto<TechnologyInfoDto>(resultCount, technologyInfoDtos);
        }

        public Task<TechnologyInfoDto> Update(TechnologyInfoDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<TechnologyInfoDto> GetById(EntityDto<long> input)
        {
            var query = await _TechnologyInfo.GetAsync(input.Id);

            return ObjectMapper.Map<TechnologyInfoDto>(query);
        }
    }
}
