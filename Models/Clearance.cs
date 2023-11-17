namespace Bmis.Models
{
    public class clearance
    {
        public int clearID { get; set; }
        public int resID { get; set; }
        public DateTime? date { get; set; } = DateTime.Now;
        public string purpose { get; set; } = "";
        public string fullname { get; set; } = "";
        public string purok { get; set; } = "";
    }
}
