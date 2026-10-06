using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditApp.DataAccess.Entities
{
    [Table("employee")]
    public class Employee
    {
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("first_name")]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Column("last_name")]
        public required string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("gender")]
        public required string Gender { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        [Column("email")]
        public required string Email { get; set; }

        [Required]
        [StringLength(255)]
        [Column("password")]
        public required string Password { get; set; }

        [Required]
        [Column("salary")]
        public decimal Salary { get; set; }
    }
}