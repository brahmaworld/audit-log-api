using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditApp.DataAccess.Entities
{
    [Table("audit_log")]
    public class AuditLog
    {
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("event_type")]
        public required string EventType { get; set; }

        [Required]
        [StringLength(255)]
        [Column("actor_id")]
        public required string ActorId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("resource_type")]
        public required string ResourceType { get; set; }

        [Required]
        [StringLength(255)]
        [Column("resource_id")]
        public required string ResourceId { get; set; }

        [Column("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [Required]
        [StringLength(64)]
        [Column("content_hash")]
        public required string ContentHash { get; set; }

        [Required]
        [StringLength(64)]
        [Column("previous_hash")]
        public required string PreviousHash { get; set; }
    }
}
