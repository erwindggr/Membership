using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Models
{
    [Table("Member")]
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        [StringLength(100)]
        [Required]
        public string? Address { get; set; }
        public int MemberTypeId { get; set; }
        public MemberType? MemberType { get; set; }
    }
}
