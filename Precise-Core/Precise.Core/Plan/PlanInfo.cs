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
    public class PlanInfo : FullAuditedEntity<long>
    {
        public string CardCode { get; set; }

        public string TechnologyCode { get; set; }

        public long ProductLineId { get; set; }

        public DateTime PlanDate { get; set; }

        public int Shifts { get; set; }

        public PlanStatus Status { get; set; }

        public DateTime? ComplatedTime { get; set; }

        public string AuditedUser { get; set; }

        public DateTime? AuditedTime { get; set; }

        public string OutCode { get; set; }
        public string Remark { get; set; }

        public virtual ProductLineInfo ProductLine { get; set; }
    }

    public enum PlanStatus
    {
        新建,
        出卡,
        配料,
        密炼,
        待检,
        完成,
        质检报废 = 40,
        生产报废 = 41,
        计划作废 = 50,
    }

    public enum Shifts
    {
        不限,
        白班,
        中班,
        晚班,
    }
}