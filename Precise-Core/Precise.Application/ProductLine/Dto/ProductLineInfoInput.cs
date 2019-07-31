using Abp.Extensions;
using Abp.Runtime.Validation;
using Precise.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Precise.ProductLine.Dto
{
    public class ProductLineInfoInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public ProductLineType? Type { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "Code DESC";
            }
            else if (Sorting.IndexOf("ProductLineType", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Sorting = "ProductLineType." + Sorting;
            }
        }
    }
}