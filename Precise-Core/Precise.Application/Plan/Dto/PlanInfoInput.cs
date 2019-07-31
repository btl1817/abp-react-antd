﻿using Abp.Extensions;
using Abp.Runtime.Validation;
using Precise.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Precise.Plan.Dto
{
    public class PlanInfoInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string CardCode { get; set; }

        public string TechnologyCode { get; set; }

        public DateTime? PlanDateStart { get; set; }
        public DateTime? PlanDateEnd { get; set; }

        public DateTime? CreateTimeStart { get; set; }
        public DateTime? CreateTimeEnd { get; set; }

        public PlanStatus? Status { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "CardCode DESC";
            }
            else if (Sorting.IndexOf("TechnologyCode", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Sorting = "TechnologyCode." + Sorting;
            }
            else if (Sorting.IndexOf("PlanData", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Sorting = "PlanData." + Sorting;
            }
            else if (Sorting.IndexOf("Status", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Sorting = "Status." + Sorting;
            }
        }
    }
}
