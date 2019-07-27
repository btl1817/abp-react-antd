using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Precise.Technology.Dto
{
    [AutoMap(typeof(TechnologyInfo))]
    public class TechnologyInfoDto : FullAuditedEntityDto<long>
    {
        public string RubberCode { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }
    }
}
