using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    public class ProjectionsImportDto
    {
        [MinLength(4)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Range(1, 10)]
        [Required]
        public sbyte NumberOfHalls { get; set; }

        [MinLength(4)]
        [MaxLength(30)]
        [Required]
        public string Director { get; set; }

        public TicketImportDto[] Tickets { get; set; }
    }
}
