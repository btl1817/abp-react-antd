using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Precise.Plan.Dto
{
    public class CreatePlanInput
    {
        [Required]
        public string TechnologyCode { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public DateTime PlanDate { get; set; }

        [Required]
        public long ProductLineId { get; set; }

        [Required]
        public int Shifts { get; set; }

        public string OutCode { get; set; }

        public string Remark { get; set; }
    }
}
