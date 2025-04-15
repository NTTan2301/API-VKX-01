using System.ComponentModel.DataAnnotations;

namespace VKX_API01.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Adress { get; set; } = string.Empty;
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;
    }
}
