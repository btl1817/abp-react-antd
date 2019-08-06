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
    public class CheckLog : CreationAuditedEntity<long>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string ProductLineName { get; set; }

        public string DeviceName { get; set; }

        public string checkItem { get; set; }

        public CheckType Type { get; set; }

        public decimal? standardValue { get; set; }

        public decimal? upperLimit { get; set; }

        public decimal? lowerLimit { get; set; }

        public decimal? checkedValue { get; set; }

        public CheckStatus status { get; set; }

        public string Remark { get; set; }

        public virtual ProductLineInfo ProductLine { get; set; }

        public virtual DeviceInfo Device { get; set; }
    }

    public enum CheckStatus
    {
        未知 = 0,
        通过 = 1,
        异常 = 32,
        忽略 = 33
    }

    public enum CheckType
    {
        手动目视 = 0,
        自动目视 = 1,
        手动自检 = 2,
        自动自检 = 3,
    }
}