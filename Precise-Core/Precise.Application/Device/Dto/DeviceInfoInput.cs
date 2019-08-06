using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Runtime.Validation;
using Precise.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Precise.Plan.Dto
{
    public class DeviceInfoInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string ProductLineName { get; set; }

        public DeviceType Type { get; set; }

        public string Remark { get; set; }

        public virtual ProductLineInfo ProductLine { get; set; }

        public string CreatedUser { get; set; }

        public void Normalize()
        {
            if (SortField.IsNullOrWhiteSpace())
                SortField = "ProductLineName,Code";

            switch (SortOrder)
            {
                case "ascend":
                    SortOrder = "Asc";
                    break;
                default:
                    SortOrder = "Desc";
                    break;
            }
        }
    }
}
