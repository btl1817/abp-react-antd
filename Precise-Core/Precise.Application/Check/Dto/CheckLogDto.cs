using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Precise.Check.Dto
{
    [AutoMap(typeof(CheckLog))]
    public class CheckLogDto : FullAuditedEntityDto<long>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string ProductLineName { get; set; }

        public string InstallLocation { get; set; }

        public DeviceType Type { get; set; }

        public decimal? standardValue { get; set; }

        public decimal? upperLimit { get; set; }

        public decimal? lowerLimit { get; set; }

        public decimal? checkedValue { get; set; }

        public CheckStatus status { get; set; }

        public string Remark { get; set; }

        public string Operater { get; set; }

    }
}
