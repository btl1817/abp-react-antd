using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Precise.Device.Dto
{
    [AutoMap(typeof(DeviceInfo))]
    public class DeviceInfoDto : FullAuditedEntityDto<long>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string ProductLineName { get; set; }

        public DeviceType Type { get; set; }

        public string Remark { get; set; }

        public virtual ProductLineInfo ProductLine { get; set; }

        public string CreatedUser { get; set; }

    }
}
