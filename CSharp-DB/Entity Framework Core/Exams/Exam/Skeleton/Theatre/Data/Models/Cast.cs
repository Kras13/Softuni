using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }

        [Required]
        public virtual Play Play { get; set; }
    }
}

