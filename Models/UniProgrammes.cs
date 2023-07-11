namespace uniPlanner.Models
{
    public class UniProgrammes
    {
        public int ID { get; set; }
        public ICollection <UniversityInfo> UniversityID { get; set;}
        public ICollection <Programmes> ProgrammeID { get; set; }
    }
}
