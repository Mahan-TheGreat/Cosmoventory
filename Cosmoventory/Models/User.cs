using System.ComponentModel.DataAnnotations;

namespace Cosmoventory.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        // Role & Status
        [Required, MaxLength(20)]
        public string Role { get; set; } = "Staff";


        // Auditing
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }

        public bool IsLocked { get; set; } = true;

        // Soft delete 
        public bool IsActive { get; set; } = true;
    }
}
