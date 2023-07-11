namespace uniPlanner.Models
{
    public class MajorsOffered
    {
        public int ID { get; set; }
        public ICollection <UniProgrammes> UniProgrammes { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }
}
