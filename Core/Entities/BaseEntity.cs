namespace Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string LastModifiedBy { get; set; } = string.Empty;
        public string CreatorPublicIp { get; set; } = string.Empty;
        public string ModifierPublicIp { get; set; } = string.Empty;
    }
}