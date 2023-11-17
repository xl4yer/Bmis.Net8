namespace Bmis.Models
{
    public class residents
    {
        public int resID { get; set; }
        public byte[]? photo { get; set; }
        public string fname { get; set; } = "";
        public string mname { get; set; } = "";
        public string lname { get; set; } = "";
        public string ext { get; set; } = "";
        public string purok { get; set; } = "";
        public string gender { get; set; } = "";
        public DateTime? bdate { get; set; } = DateTime.Now;
        public string status { get; set; } = "";
        public string contact { get; set; } = "";
        public string fullname { get; set; } = "";
    }
}
