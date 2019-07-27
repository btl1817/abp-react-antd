using Abp.Domain.Entities.Auditing;
using Precise.Materials;

namespace Precise
{
    public class TechnologyFeed : AuditedEntity<long>
    {
        public ushort Step { get; set; }

        public string MaterialsCode { get; set; }

        public decimal StandardWeight { get; set; }

        public decimal ErrorWeight { get; set; }

        public MaterialsType MaterialsType { get; set; }
    }
}