using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Precise.Plan.Dto
{
    public class PlanInfoMCreate
    {
        public string TechnologyCode { get; set; }

        public string ProductLine { get; set; }

        public int Shifts { get; set; }

        public DateTime PlanDate { get; set; }

        public int Qty { get; set; }

    }
}
