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

        public string Shifts { get; set; }

        public PlanStatus Status { get; set; }

        public DateTime? ComplatedTime { get; set; }

        public string AuditedUser { get; set; }

        public DateTime? AuditedTime { get; set; }

        public virtual ProductLineInfo ProductLine { get; set; }
    }

    public enum PlanStatus
    {
        新建,
        执行,
        完成,
        审核完成,
        审核作废,
        作废,
    }

    public enum Shifts
    {
        不限,
        白班,
        中班,
        晚班,
    }
}