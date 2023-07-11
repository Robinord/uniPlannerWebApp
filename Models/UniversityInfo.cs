using System.Reflection.Metadata.Ecma335;

namespace uniPlanner.Models
{
    public class UniversityInfo
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public int THErank { get; set; }
        public int QSrank { get; set; }
        public int ARWUrank { get; set; }
    }
}
