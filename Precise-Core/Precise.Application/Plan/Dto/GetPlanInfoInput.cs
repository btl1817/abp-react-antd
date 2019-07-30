using Abp.Extensions;
using Abp.Runtime.Validation;
using Precise.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Precise.Technology.Dto
{
    public class GetPlanInfoInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string RubberCode { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "RubberCode DESC";
            }
            else if (Sorting.IndexOf("Code", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Sorting = "Code." + Sorting;
            }
            else if (Sorting.IndexOf("Status", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Sorting = "Status." + Sorting;
            }
        }
    }
}
