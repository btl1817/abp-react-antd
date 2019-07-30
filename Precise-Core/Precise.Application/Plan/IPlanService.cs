using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Precise.Technology.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Precise.Plan
{
    public interface IPlanService : IAsyncCrudAppService<PlanInfoDto, long, GetPlanInfoInput>
    {
        Task<PlanInfoDto> GetById(EntityDto<long> input);
    }
}
