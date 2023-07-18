using System.ComponentModel.DataAnnotations;

namespace uniPlanner.Models
{
    public class UniversityInfo
    {

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public int THErank { get; set; }
        [Required]
        public int QSrank { get; set; }
        [Required]
        public int ARWUrank { get; set; }
    }
}
