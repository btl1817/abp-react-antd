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
    public class ProductLineInfo : FullAuditedEntity<long>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public ProductLineType Type { get; set; }
    }

    public enum ProductLineType
    {
        未知,
        配料,
        密炼,
        仓库,
    }
}