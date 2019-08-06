using System;
using Abp.Authorization.Users;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;
using Abp.Timing;
using Precise.Authorization.Users;

namespace Precise
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class DeviceInfo : FullAuditedEntity<long>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string ProductLineName { get; set; }

        public DeviceType Type { get; set; }

        public string Remark { get; set; }

        public virtual ProductLineInfo ProductLine { get; set; }
    }

    public enum DeviceType
    {
        未知 = 0,
        仓库 = 0x10,
        配料 = 0x20,
        小药配料 = 0x21,
        炭黑配料 = 0x22,
        生胶配料 = 0x23,
        油料配料 = 0x24,
        密炼 = 0x40,
        密炼机 = 0x41,
        提升机 = 0x42,
        开炼机 = 0x43,

    }
}