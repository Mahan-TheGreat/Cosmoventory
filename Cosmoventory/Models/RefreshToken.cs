using System.ComponentModel.DataAnnotations.Schema;

namespace Cosmoventory.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
        public bool IsActive => RevokedAt == null && !IsExpired;

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
       
    }
}
