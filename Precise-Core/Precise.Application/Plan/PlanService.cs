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
using System.Linq;
using Abp.Authorization;
using Precise.Authorization.Users;
using Precise.Plan.Dto;

namespace Precise.Plan
{
    [AbpAuthorize]
    public class PlanService : PreciseAppServiceBase, IPlanService
    {
        private readonly IRepository<PlanInfo, long> _planInfo;
        private readonly IRepository<User, long> _userManager;
        public PlanService(IRepository<PlanInfo, long> planInfo, IRepository<User, long> userManager)
        {
            _planInfo = planInfo;
            _userManager = userManager;
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
            var query = await _planInfo.GetAsync(input.Id);

            return ObjectMapper.Map<PlanInfoDto>(query);
        }

        public async Task<PagedResultDto<PlanInfoDto>> GetAll(PlanInfoInput input)
        {
            var query = from pi in _planInfo.GetAll()
                        join au in _userManager.GetAll() on pi.CreatorUserId equals au.Id
                        select new
                        {
                            CardCode = pi.CardCode,
                            CreatedTime = pi.CreationTime.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                            CreatedUser = au.Surname + au.Name,
                            CreationTime = pi.CreationTime,
                            CreatorUserId = pi.CreatorUserId,
                            DeleterUserId = pi.DeleterUserId,
                            DeletionTime = pi.DeletionTime,
                            Id = pi.Id,
                            IsDeleted = pi.IsDeleted,
                            LastModificationTime = pi.LastModificationTime,
                            LastModifierUserId = pi.LastModifierUserId,
                            PlanDate = pi.PlanDate.ToString("yyyy-MM-dd"),
                            Status = pi.Status,
                            TechnologyCode = pi.TechnologyCode,
                            PlanDateD = pi.PlanDate,
                            ProductLineName = pi.ProductLine.Name,
                            ProductLineId = pi.ProductLineId,
                            Shifts = pi.Shifts.ToString(),

                        };

            query = query
                .WhereIf(!input.CardCode.IsNullOrWhiteSpace(), item => item.CardCode.Contains(input.CardCode))
                .WhereIf(!input.TechnologyCode.IsNullOrWhiteSpace(), item => item.TechnologyCode.Contains(input.TechnologyCode))
                .WhereIf(input.Status.HasValue, item => item.Status.Equals(input.Status.Value))
                .WhereIf(input.PlanDateStart != null && input.PlanDateEnd != null, item => input.PlanDateStart <= item.PlanDateD && item.PlanDateD < input.PlanDateEnd)
                .WhereIf(input.CreateTimeStart != null && input.CreateTimeEnd != null, item => input.CreateTimeStart <= item.CreationTime && item.CreationTime < input.CreateTimeEnd)
                ;

            var resultCount = await query.CountAsync();
            var results = await query
                .OrderBy(input.SortField + ' ' + input.SortOrder)
                .PageBy(input)
                .ToListAsync();

            var planInfoDtos = ObjectMapper.Map<IReadOnlyList<PlanInfoDto>>(results);

            return new PagedResultDto<PlanInfoDto>(resultCount, planInfoDtos);
        }

        public Task<PlanInfoDto> Update(PlanInfoDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<PlanInfoDto> GetById(EntityDto<long> input)
        {
            var query = await _planInfo.GetAsync(input.Id);

            return ObjectMapper.Map<PlanInfoDto>(query);
        }

        public async Task CreatePlans(CreatePlanInput input)
        {
            for (int i = 1; i < input.Qty; i++)
            {
                await _planInfo.InsertAsync(new PlanInfo
                {
                    CardCode = DateTime.Now.ToString("yyyyMMddHHmmss") + i.ToString("000"),
                    CreationTime = DateTime.Now,
                    Shifts = input.Shifts,
                    IsDeleted = false,
                    Status = 0,
                    PlanDate = input.PlanDate.Date,
                    ProductLineId = input.ProductLineId,
                    TechnologyCode = input.TechnologyCode,
                    OutCode = input.OutCode,
                    Remark = input.Remark,
                });
            }
        }

        public async Task NullifyPlan(EntityDto<long> input)
        {
            var query = await _planInfo.GetAsync(input.Id);
            query.Status = PlanStatus.计划作废;
            await _planInfo.UpdateAsync(query);
        }
    }
}
