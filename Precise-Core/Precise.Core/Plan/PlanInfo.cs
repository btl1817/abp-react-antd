using System;
using Abp.Authorization.Users;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;
using Abp.Timing;

namespace Precise
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class PlanInfo : FullAuditedEntity<long>
    {
        public string CardCode { get; set; }

        public string TechnologyCode { get; set; }

        public string PlanData { get; set; }

        public string Status { get; set; }
    }
}