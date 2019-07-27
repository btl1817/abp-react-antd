
using Abp.Domain.Entities.Auditing;

namespace Precise
{
    public class TechnologyStep : AuditedEntity<long>
    {
        public ushort Step { get; set; }

        public string Name { get; set; }

        public ushort ControlTemp { get; set; }
        public ushort ControlTime { get; set; }
        public ushort ControlPower { get; set; }
        public ushort ControlType { get; set; }
        public ushort AStopTime { get; set; }
        public ushort BStopTime { get; set; }
        public ushort CStopTime { get; set; }
        public ushort ColdWaterTemp { get; set; }
        public ushort FeedMaxTemp { get; set; }
        public ushort FeedMinTemp { get; set; }

        public string Remark { get; set; }



        public TechnologyInfo Technology { get; set; }

    }
}