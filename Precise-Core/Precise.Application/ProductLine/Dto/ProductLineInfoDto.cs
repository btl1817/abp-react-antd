using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Precise.ProductLine.Dto
{
    [AutoMap(typeof(ProductLineInfo))]
    public class ProductLineInfoDto : FullAuditedEntityDto<long>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public ProductLineType Type { get; set; }
    }
}
