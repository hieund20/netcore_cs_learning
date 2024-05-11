namespace MonitorTableChange.Models
{
    public class MonitorEvent
    {
        public Guid MonitorEventId { get; set; }
        public Guid TableId { get; set; }
        public string TableName { get; set; }
        public string TypeChange { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
