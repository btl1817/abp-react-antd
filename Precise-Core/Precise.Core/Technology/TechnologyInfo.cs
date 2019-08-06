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
    public class TechnologyInfo : FullAuditedEntity<long>
    {
        public string RubberCode { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string ProduceLines { get; set; }

        public virtual TechnologyStep[] Steps { get; set; }
        public virtual TechnologyFeed[] Feeds { get; set; }
    }
}