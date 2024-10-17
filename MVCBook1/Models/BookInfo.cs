using System.ComponentModel.DataAnnotations;

namespace MVCBook1.Models
{
    public class BookInfo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(35)]
        public string BookName { get; set; }
        [Required]
        [MaxLength(35)]
        public string Genre { get; set; }
        public bool AvailabilityStatus { get; set; }
    }
}
