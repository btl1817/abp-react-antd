using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Precise.Plan.Dto
{
    [AutoMap(typeof(PlanInfo))]
    public class PlanInfoDto : FullAuditedEntityDto<long>
    {
        public string CardCode { get; set; }

        public string TechnologyCode { get; set; }

        public string PlanDate { get; set; }

        public long ProductLineId { get; set; }

        public string ProductLineName { get; set; }

        public int Shifts { get; set; }

        public PlanStatus Status { get; set; }

        public string CreatedTime { get; set; }

        public string CreatedUser { get; set; }

    }
}
