using System.Reflection.Metadata.Ecma335;

namespace uniPlanner.Models
{
    public class UniversityInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int THErank { get; set; }
        public int QSrank { get; set; }
        public int ARWUrank { get; set; }
    }
}
