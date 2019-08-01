using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Precise.Plan.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Precise.Plan
{
    public interface IPlanService : IAsyncCrudAppService<PlanInfoDto, long, PlanInfoInput>
    {
        Task<PlanInfoDto> GetById(EntityDto<long> input);
        
        Task CreatePlans(CreatePlanInput input);
    }
}
