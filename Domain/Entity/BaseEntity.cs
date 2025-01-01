using Quotation.Domain.Enums;

namespace Quotation.Domain.Entity
{
    public record BaseEntity
    {
        public Guid Uid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? LastModified { get; set; }
        public StatusEnumerator Status { get; set; } = StatusEnumerator.Active;
    }
}
