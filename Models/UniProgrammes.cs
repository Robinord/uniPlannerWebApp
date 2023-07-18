using System.ComponentModel.DataAnnotations;

namespace uniPlanner.Models
{
    public class UniProgrammes
    {
        public required int ID { get; set; }
        public required ICollection<UniversityInfo> UniversityID { get; set;}
        public required ICollection<Programmes> ProgrammeID { get; set; }
        public required string Link { get; set; }
        [Range(0, 320, ErrorMessage = "Please enter correct value")]
        public int? RankScore { get; set; }
    }
}
