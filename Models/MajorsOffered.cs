namespace uniPlanner.Models
{
    public class MajorsOffered
    {
        public required int ID { get; set; }
        public required ICollection <UniProgrammes> UniProgrammes { get; set; }
        public required string name { get; set; }
        public string link { get; set; }
    }
}
