using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class CastImportDto
    {
        [XmlElement("FullName")]
        [MinLength(4)]
        [MaxLength(30)]
        [Required]
        public string FullName { get; set; }

        [XmlElement("IsMainCharacter")]
        [Required]
        public string IsMainCharacter { get; set; }

        [XmlElement("PhoneNumber")]
        [Required]
        [RegularExpression(@"^\+44\-\d\d\-\d\d\d\-\d\d\d\d$")]
        public string PhoneNumber { get; set; }

        [XmlElement("PlayId")]
        [Required]
        public int PlayId { get; set; }
    }
}
