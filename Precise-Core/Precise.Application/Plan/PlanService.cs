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

namespace Precise.Plan
{
    [AbpAuthorize]
    public class PlanService : PreciseAppServiceBase, IPlanService
    {
        private readonly IRepository<PlanInfo, long> _PlanInfo;
        public PlanService(IRepository<PlanInfo, long> tlanInfo)
        {
            _PlanInfo = tlanInfo;
        }

        public Task<PlanInfoDto> Create(PlanInfoDto input)
        {
            throw new NotImplementedException();
        }

        public Task Delete(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public async Task<PlanInfoDto> Get(EntityDto<long> input)
        {
            var query = await _PlanInfo.GetAsync(input.Id);

            return ObjectMapper.Map<PlanInfoDto>(query);
        }

        public async Task<PagedResultDto<PlanInfoDto>> GetAll(GetPlanInfoInput input)
        {
            var query = _PlanInfo.GetAll();

            query = query
                //.WhereIf(!input.Code.IsNullOrWhiteSpace(), item => item.Code.Contains(input.Code))
                //.WhereIf(!input.RubberCode.IsNullOrWhiteSpace(), item => item.RubberCode.Contains(input.RubberCode))
                ;

            var resultCount = await query.CountAsync();
            var results = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var planInfoDtos = ObjectMapper.Map<IReadOnlyList<PlanInfoDto>>(results);

            return new PagedResultDto<PlanInfoDto>(resultCount, tlanInfoDtos);
        }

        public Task<PlanInfoDto> Update(PlanInfoDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<PlanInfoDto> GetById(EntityDto<long> input)
        {
            var query = await _PlanInfo.GetAsync(input.Id);

            return ObjectMapper.Map<TechnologyInfoDto>(query);
        }
    }
}
